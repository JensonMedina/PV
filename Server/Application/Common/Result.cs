namespace Application.Common
{
    public class Result<T>
    {
        #region Definición propiedades/variables
        // Indica si la operación fue exitosa
        public bool Success { get; set; }

        // Mensaje descriptivo de la operación
        public string Message { get; set; }

        // Datos retornados por la operación
        public T? Data { get; set; }

        // Código de estado HTTP
        public int StatusCode { get; set; }

        /// Detalles adicionales o errores específicos
        public object Errors { get; set; }
        #endregion

        /// <summary>
        /// Constructor para respuesta exitosa con datos
        /// </summary>
        public static Result<T> Ok(T data, string message = "Operación exitosa")
        {
            return new Result<T>
            {
                Success = true,
                Message = message,
                Data = data,
                StatusCode = 200,
                Errors = null
            };
        }
        /// <summary>
        /// Constructor para respuesta exitosa sin datos
        /// </summary>
        public static Result<T> Ok(string message = "Operación exitosa")
        {
            return new Result<T>
            {
                Success = true,
                Message = message,
                Data = default,
                StatusCode = 200,
                Errors = null
            };
        }


        /// <summary>
        /// Constructor para respuesta con error de tipo BadRquest
        /// </summary>
        public static Result<T> BadRequest(string message = "Ha ocurrido un error", object errors = null, int statusCode = 400)
        {
            return new Result<T>
            {
                Success = false,
                Message = message,
                Data = default,
                StatusCode = statusCode,
                Errors = errors
            };
        }
        /// <summary>
        /// Constructor para respuesta con error inesperado
        /// </summary>
        public static Result<T> Error(string message = "Ha ocurrido un error", object errors = null, int statusCode = 500)
        {
            return new Result<T>
            {
                Success = false,
                Message = message,
                Data = default,
                StatusCode = statusCode,
                Errors = errors
            };
        }

        /// <summary>
        /// Constructor para respuesta con error no encontrado
        /// </summary>
        public static Result<T> NotFound(string message = "Recurso no encontrado")
        {
            return new Result<T>
            {
                Success = false,
                Message = message,
                Data = default,
                StatusCode = 404,
                Errors = null
            };
        }
        public static Result<T> Conflict(string message = "Error de conflicto", object errors = null, int statusCode = 409)
        {
            return new Result<T>
            {
                Success = false,
                Message = message,
                Data = default,
                StatusCode = statusCode,
                Errors = errors
            };
        }

        /// <summary>
        /// Constructor para respuesta con error no autorizado
        /// </summary>
        public static Result<T> Unauthorized(string message = "No autorizado")
        {
            return new Result<T>
            {
                Success = false,
                Message = message,
                Data = default,
                StatusCode = 401,
                Errors = null
            };
        }
        public static Result<T> Forbidden(string message = "Acceso denegado")
        {
            return new Result<T>
            {
                Success = false,
                Message = message,
                Data = default,
                StatusCode = 403,
                Errors = null
            };
        }

        /// <summary>
        /// Constructor para respuesta con error de validación
        /// </summary>
        public static Result<T> ValidationError(object errors, string message = "Error de validación")
        {
            return new Result<T>
            {
                Success = false,
                Message = message,
                Data = default,
                StatusCode = 422,
                Errors = errors
            };
        }
        /// <summary>
        /// Constructor para respuesta con error de tipo Forbidden
        /// </summary>

    }
}