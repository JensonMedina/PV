using Application.Common;
using Application.Interfaces;
using Application.Mappings;
using Application.Models.Request;
using Domain.Entities;
using Domain.Enum;

namespace Application.Services
{
    public class NegocioService : INegocioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerApp _logger;
        private readonly IRubroService _rubroService;
        private readonly IPlanSaasService _planSaasService;
        private readonly IMedioPagoService _medioPagoService;
        public NegocioService(
         IUnitOfWork unitOfWork,
         ILoggerApp logger,
         IRubroService rubroService,
         IPlanSaasService planSaasService,
         IMedioPagoService medioPagoService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _rubroService = rubroService;
            _planSaasService = planSaasService;
            _medioPagoService = medioPagoService;
        }

        /// <summary>
        /// Método usado para registrar un negocio por primera vez.
        /// </summary>
        /// <param name="newNegocio"></param>
        /// <returns></returns>
        public async Task Register(NegocioRequest newNegocio)
        {
            _logger.LogInfo(this.GetType().Name, $"Ejecutando método Register. Se intenta registrar el negocio: {newNegocio.Nombre}");
            Negocio? negocio = null;
            try
            {
                #region Validaciones

                // Validar Rubro
                var rubro = await _rubroService.ValidateRubro(newNegocio.RubroId);


                //Validar PlanSaas
                var plansaas = await _planSaasService.ValidatePlanSaas(newNegocio.PlanSaasId);

                #region Validamos que tipo de documento y nro de documento vengan juntos
                if (newNegocio.NumeroDocumento is not null)
                {
                    if (newNegocio.TipoDocumento is null)
                    {
                        _logger.LogError(this.GetType().Name, $"Ejecutando método Register. Se está enviando un nro de documento sin el tipo.");
                        throw ExceptionApp.BadRequest("Falta el atributo TipoDocumento");
                    }
                }
                if (newNegocio.TipoDocumento is not null)
                {
                    if (newNegocio.NumeroDocumento is null)
                    {
                        _logger.LogError(this.GetType().Name, $"Ejecutando método Register. Se está enviando un tipo de documento sin el nro.");
                        throw ExceptionApp.BadRequest("Falta el atributo NumeroDocumento");
                    }
                }

                #endregion

                #region Validamos que si vienen ambos datos (tipo y nro de doc), no existe otro negocio con los mismos datos
                if (newNegocio.TipoDocumento is not null && newNegocio.NumeroDocumento is not null)
                {
                    Negocio? negocioExistente = await ValidateByNroDocumento((TipoDocumento)newNegocio.TipoDocumento, newNegocio.NumeroDocumento);
                    
                    if (negocioExistente is not null)
                    {
                        _logger.LogError(this.GetType().Name, $"Ejecutando método Register. El tipo y nro de documento que se está intentando usar ya está en uso.");
                        throw ExceptionApp.BadRequest("El tipo y nro de documento que se está intentando usar ya está en uso.");

                    }
                }
                #endregion

                #region Validamos que no haya otro negocio con el mismo Correo
                if (newNegocio.Email is not null)
                {
                    Negocio? negocioExistente = await ValidateByEmail(newNegocio.Email);
                    if (negocioExistente is not null)
                    {
                        _logger.LogError(this.GetType().Name, $"Ejecutando método Register. El correo que se está intentando usar ya está en uso.");
                        throw ExceptionApp.BadRequest("El correo que se está intentando usar ya está en uso.");

                    }
                }
                #endregion

                #endregion

                #region mapeamos de Request a entidad
                try
                {
                    _logger.LogInfo(this.GetType().Name, $"Ejecutando método Register. Mapeando de NegocioRequest a Negocio");
                    negocio = NegocioMapping.ToEntity(newNegocio);
                }
                catch (Exception ex)
                {
                    _logger.LogError(this.GetType().Name, $"Ocurrió un error al intentar mapear de NegocioRequest a Negocio. Error: {ex.Message}");
                    throw; //lanzamos la exception para poder trasladarla hasta llegar al cliente
                }
                #endregion

                #region Invocamos al repositorio del Negocio
                await _unitOfWork.Negocios.Register(negocio);
                await _unitOfWork.CompleteAsync();
                _logger.LogInfo(this.GetType().Name, "Se terminó de ejecutar con éxito el método Register");
                #endregion

                #region Validar y registrar medio de pago
                await _medioPagoService.Register(newNegocio.MedioPagoRequest, negocio);
                #endregion
            }
            catch (Exception ex)
            {
                var errorDetails = $@"
                Ocurrió un error en el método: {this.GetType().Name} - Register
                Negocio: {newNegocio.Nombre}
                Mensaje de Error: {ex.Message}
                StackTrace: {ex.StackTrace}
                InnerException: {(ex.InnerException != null ? ex.InnerException.Message : "No hay InnerException")}
                ";
                _logger.LogError(this.GetType().Name, errorDetails);
                throw; //lanzamos la exception para poder trasladarla hasta llegar al cliente
            }
        }
        /// <summary>
        /// Método usado para modificar un negocio.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="negocioRequest"></param>
        /// <returns></returns>
        public async Task Modify(NegocioModifiedRequest negocioRequest)
        {
            _logger.LogInfo(this.GetType().Name, $"Ejecutando método Modify. Se intenta modificar el negocio con Id: {negocioRequest.Id}");

            try
            {
                #region Validaciones
                //Validamos si existe el negocio
                Negocio negocio = await ValidateById(negocioRequest.Id);

                //si recibimos el id de un rubro, validamos que exista dicho rubro
                if (negocioRequest.RubroId is not null)
                {
                    _ = await _rubroService.ValidateRubro((int)negocioRequest.RubroId);
                }

                //si recibimos el id de un plan, validamos que exista dicho plan
                if (negocioRequest.PlanSaasId is not null)
                {
                    _ = await _planSaasService.ValidatePlanSaas((int)negocioRequest.PlanSaasId);
                }

                #region Validamos que tipo de documento y nro de documento vengan juntos
                if (negocioRequest.NumeroDocumento is not null)
                {
                    if (negocioRequest.TipoDocumento is null)
                    {
                        _logger.LogError(this.GetType().Name, $"Ejecutando método Modify. Se está enviando un nro de documento sin el tipo.");
                        throw ExceptionApp.BadRequest("Falta el atributo TipoDocumento");
                    }
                }
                if (negocioRequest.TipoDocumento is not null)
                {
                    if (negocioRequest.NumeroDocumento is null)
                    {
                        _logger.LogError(this.GetType().Name, $"Ejecutando método Modify. Se está enviando un tipo de documento sin el nro.");
                        throw ExceptionApp.BadRequest("Falta el atributo NumeroDocumento");
                    }
                }

                #region Validamos que si vienen ambos datos, no existe otro negocio con los mismos datos
                if (negocioRequest.TipoDocumento is not null && negocioRequest.NumeroDocumento is not null)
                {
                    Negocio? negocioExistente = await ValidateByNroDocumento((TipoDocumento)negocioRequest.TipoDocumento, negocioRequest.NumeroDocumento);
                    //Si ya existe algún negocio con estos datos, validamos que dicho negocio sea distinto al que estamos intentando modificar
                    if (negocioExistente is not null)
                    {
                        if (!negocioExistente.Id.Equals(negocioRequest.Id))
                        {
                            //Significa que el negocio no es el mismo, por lo que ya hay en base de datos un negocio con tipo y nro de documento iguales al que se está intentando usar para este negocio
                            _logger.LogError(this.GetType().Name, $"Ejecutando método Modify. El tipo y nro de documento que se está intentando usar ya está en uso.");
                            throw ExceptionApp.BadRequest("El tipo y nro de documento que se está intentando usar ya está en uso.");
                        }
                    }
                }
                #endregion

                #endregion

                #region Validamos que no haya otro negocio con el mismo Correo
                if (negocioRequest.Email is not null)
                {
                    Negocio? negocioExistente = await ValidateByEmail(negocioRequest.Email);
                    if (negocioExistente is not null)
                    {
                        //Si ya existe un negocio con este email, vamos a verificar que ademas el negocio sea distinto al que estamos intentando modificar
                        if (!negocioExistente.Id.Equals(negocioRequest.Id))
                        {
                            //Significa que el negocio no es el mismo, por lo que ya hay en base de datos un negocio que esta usando este correo.
                            _logger.LogError(this.GetType().Name, $"Ejecutando método Modify. El correo que se está intentando usar ya está en uso.");
                            throw ExceptionApp.BadRequest("El correo que se está intentando usar ya está en uso.");
                        }
                    }
                }
                #endregion

                //El nro de telefono no lo validamos por ahora...

                #endregion

                #region Mapeamos
                try
                {
                    _logger.LogInfo(this.GetType().Name, $"Ejecutando método Modify. Mapeando de NegocioModifiedRequest a Negocio");
                    negocio = NegocioMapping.ModifiedToEntity(negocioRequest, negocio);
                }
                catch (Exception ex)
                {
                    _logger.LogError(this.GetType().Name, $"Ocurrió un error al intentar mapear de NegocioModifiedRequest a Negocio. Error: {ex.ToString()}");
                    throw;
                }
                #endregion

                #region Llamos al repositorio
                _unitOfWork.Negocios.UpdateAsync(negocio);
                await _unitOfWork.CompleteAsync();
                _logger.LogInfo(this.GetType().Name, "Se terminó de ejecutar con éxito el método Modify");
                #endregion
            }
            catch (Exception ex)
            {
                _logger.LogError(this.GetType().Name, $"Ocurrió un error en el método Modify. Error: {ex.ToString()}");
                throw;
            }
        }
        /// <summary>
        /// Método usado para deshabilitar un negocio.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Disable(int id)
        {
            _logger.LogInfo(this.GetType().Name, $"Ejecutando método Disable. Se intenta dehabilitar el negocio con Id: {id}");

            try
            {
                #region Validar si exite el negocio
                Negocio? negocio = await ValidateById(id);
                #endregion

                #region Validamos que no esté desactivado el negocio
                if(negocio is not null)
                {
                    if (!negocio.Activo)
                    {
                        _logger.LogError(this.GetType().Name, $"Ejecutando método Disable. Se intenta deshabilitar un negocio que ya se encuentra deshabilitado.");
                        throw ExceptionApp.BadRequest("Se intenta deshabilitar un negocio que ya se encuentra deshabilitado.");
                    }
                }
                #endregion

                #region Llamos al repositorio
                await _unitOfWork.Negocios.SoftDeleteAsync(id);
                await _unitOfWork.CompleteAsync();
                _logger.LogInfo(this.GetType().Name, "Se terminó de ejecutar con éxito el método Disable");
                #endregion
            }
            catch (Exception ex)
            {
                _logger.LogError(this.GetType().Name, $"Ocurrió un error en el método Disable. Error: {ex}");
                throw;
            }
        }
        /// <summary>
        /// Método usado para validar la existencia de un negocio a partir de un id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Negocio> ValidateById(int id)
        {
            _logger.LogInfo(this.GetType().Name, $"Ejecutando método ValidarNegocio. Se consulta la existencia del negocio con Id: {id}");
            Negocio? negocio = null;
            try
            {
                negocio = await _unitOfWork.Negocios.GetByIdAsync(id);
                if (negocio == null)
                {
                    _logger.LogInfo(this.GetType().Name, $"Ejecutando método ValidarNegocio. No se encontró el negocio con Id: {id}");
                    throw ExceptionApp.NotFound($"No se encontró el negocio con id: {id}");
                }
                return negocio;
            }
            catch (Exception ex)
            {
                _logger.LogError(this.GetType().Name, $"Ocurrió un error en el método ValidarNegocio. Error: {ex.ToString()}");
                throw; //lanzamos la exception para poder trasladarla hasta llegar al cliente
            }
        }
        /// <summary>
        /// Método usado para validar la existencia de algún negocio a partir del tipo y nro de documento.
        /// </summary>
        /// <param name="tipoDocumento"></param>
        /// <param name="nroDocumento"></param>
        /// <returns></returns>
        private async Task<Negocio?> ValidateByNroDocumento(TipoDocumento tipoDocumento, string nroDocumento)
        {
            _logger.LogInfo(this.GetType().Name, $"Ejecutando método ValidateNegocioByNroDocumento. Se valida la existencia de algún negocio con TipoDocumento: {tipoDocumento} y NumeroDocumento: {nroDocumento}");
            Negocio? negocio = null;
            try
            {
                negocio = await _unitOfWork.Negocios.GetByNroDocumento(tipoDocumento, nroDocumento);
                if (negocio == null)
                {
                    _logger.LogInfo(this.GetType().Name, $"Ejecutando método ValidateNegocioByNroDocumento. No se encontró algún negocio con TipoDocumento: {tipoDocumento} y NumeroDocumento: {nroDocumento}");
                    return null;
                }
                _logger.LogInfo(this.GetType().Name, $"Ejecutando método ValidateNegocioByNroDocumento. Se encontró un negocio con TipoDocumento: {tipoDocumento} y NumeroDocumento: {nroDocumento}. NegocioId: {negocio.Id}");
                return negocio;
            }
            catch (Exception ex)
            {
                _logger.LogError(this.GetType().Name, $"Ocurrió un error en el método ValidateNegocioByNroDocumento. Error: {ex.ToString()}");
                throw; //lanzamos la exception para poder trasladarla hasta llegar al cliente
            }
        }
        /// <summary>
        /// Método usado para validar si existe algún negocio a partir del email.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        private async Task<Negocio?> ValidateByEmail(string email)
        {
            _logger.LogInfo(this.GetType().Name, $"Ejecutando método ValidateByEmail. Se valida la existencia de algún negocio con Email: {email}.");
            Negocio? negocio = null;
            try
            {
                negocio = await _unitOfWork.Negocios.GetByEmail(email);
                if (negocio == null)
                {
                    _logger.LogInfo(this.GetType().Name, $"Ejecutando método ValidateByEmail. No se encontró algún negocio con Email: {email}.");
                    return null;
                }
                _logger.LogInfo(this.GetType().Name, $"Ejecutando método ValidateByEmail. Se encontró un negocio con Email: {email}. NegocioId: {negocio.Id}");
                return negocio;
            }
            catch (Exception ex)
            {
                _logger.LogError(this.GetType().Name, $"Ocurrió un error en el método ValidateByEmail. Error: {ex.ToString()}");
                throw; //lanzamos la exception para poder trasladarla hasta llegar al cliente
            }
        }
    }
}
