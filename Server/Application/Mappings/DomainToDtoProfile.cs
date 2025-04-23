using Application.Models.Request;
using Application.Models.Response;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class DomainToDtoProfile : Profile
    {
        public DomainToDtoProfile()
        {
            // ==== Request -> Domain ====
            CreateMap<RubroRequest, Rubro>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<CategoriaRequest, Categoria>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.FechaAlta, opt => opt.Ignore())
                .ForMember(dest => dest.RowVersion, opt => opt.Ignore());

            CreateMap<UnidadMedidaRequest, UnidadMedida>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<ProductoRequest, Producto>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Categoria, opt => opt.Ignore())
                .ForMember(dest => dest.Rubro, opt => opt.Ignore())
                .ForMember(dest => dest.UnidadMedida, opt => opt.Ignore())
                .ForMember(dest => dest.Negocio, opt => opt.Ignore())
                .ForMember(dest => dest.FechaAlta, opt => opt.Ignore());

            CreateMap<ProductoNegocioRequest, ProductoNegocio>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Negocio, opt => opt.Ignore())
                .ForMember(dest => dest.Producto, opt => opt.Ignore())
                .ForMember(dest => dest.Moneda, opt => opt.Ignore())
                .ForMember(dest => dest.RowVersion, opt => opt.Ignore());

            CreateMap<VentaDetalleRequest, VentaDetalle>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Producto, opt => opt.Ignore());

            CreateMap<VentaRequest, Venta>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.AfectaCaja, opt => opt.Ignore())
                .ForMember(dest => dest.ComprobanteId, opt => opt.Ignore())
                .ForMember(dest => dest.Comprobante, opt => opt.Ignore())
                .ForMember(dest => dest.Negocio, opt => opt.Ignore())
                .ForMember(dest => dest.Puesto, opt => opt.Ignore())
                .ForMember(dest => dest.Empleado, opt => opt.Ignore())
                .ForMember(dest => dest.Cliente, opt => opt.Ignore())
                .ForMember(dest => dest.ComprobanteAnulacionId, opt => opt.Ignore())
                .ForMember(dest => dest.ComprobanteAnulacion, opt => opt.Ignore())
                .ForMember(dest => dest.RowVersion, opt => opt.Ignore());

            CreateMap<CompraDetalleRequest, CompraDetalle>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Producto, opt => opt.Ignore());

            CreateMap<CompraRequest, Compra>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Negocio, opt => opt.Ignore())
                .ForMember(dest => dest.Proveedor, opt => opt.Ignore())
                .ForMember(dest => dest.Usuario, opt => opt.Ignore())
                .ForMember(dest => dest.Comprobante, opt => opt.Ignore())
                .ForMember(dest => dest.ComprobanteAnulacion, opt => opt.Ignore())
                .ForMember(dest => dest.RowVersion, opt => opt.Ignore());

            CreateMap<ClienteRequest, Cliente>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.EsEmpresa, opt => opt.Ignore())
                .ForMember(dest => dest.Email, opt => opt.Ignore())
                .ForMember(dest => dest.NegocioId, opt => opt.Ignore())
                .ForMember(dest => dest.Negocio, opt => opt.Ignore())
                .ForMember(dest => dest.FechaAlta, opt => opt.Ignore())
                .ForMember(dest => dest.RowVersion, opt => opt.Ignore());

            CreateMap<ComprobanteRequest, Comprobante>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<HistoricoPrecioRequest, HistoricoPrecio>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ProductoNegocio, opt => opt.Ignore())
                .ForMember(dest => dest.Precio, opt => opt.Ignore())
                .ForMember(dest => dest.Fecha, opt => opt.Ignore());

            CreateMap<HistoricoStockRequest, HistoricoStock>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ProductoNegocio, opt => opt.Ignore())
                .ForMember(dest => dest.Stock, opt => opt.Ignore())
                .ForMember(dest => dest.Fecha, opt => opt.Ignore());

            CreateMap<NegocioRequest, Negocio>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Calle, opt => opt.Ignore())
                .ForMember(dest => dest.Altura, opt => opt.Ignore())
                .ForMember(dest => dest.Ciudad, opt => opt.Ignore())
                .ForMember(dest => dest.Provincia, opt => opt.Ignore())
                .ForMember(dest => dest.Pais, opt => opt.Ignore())
                .ForMember(dest => dest.CodigoPostal, opt => opt.Ignore())
                .ForMember(dest => dest.LogoUrl, opt => opt.Ignore())
                .ForMember(dest => dest.Rubro, opt => opt.Ignore())
                .ForMember(dest => dest.FechaAlta, opt => opt.Ignore())
                .ForMember(dest => dest.Activo, opt => opt.Ignore())
                .ForMember(dest => dest.PlanSaas, opt => opt.Ignore())
                .ForMember(dest => dest.RowVersion, opt => opt.Ignore());

            CreateMap<PlanSaasRequest, PlanSaas>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<ProveedorRequest, Proveedor>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Direccion, opt => opt.Ignore())
                .ForMember(dest => dest.Ciudad, opt => opt.Ignore())
                .ForMember(dest => dest.Provincia, opt => opt.Ignore())
                .ForMember(dest => dest.CodigoPostal, opt => opt.Ignore())
                .ForMember(dest => dest.Web, opt => opt.Ignore())
                .ForMember(dest => dest.FechaAlta, opt => opt.Ignore())
                .ForMember(dest => dest.Rubro, opt => opt.Ignore())
                .ForMember(dest => dest.RowVersion, opt => opt.Ignore());

            CreateMap<PuestoRequest, Puesto>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.NegocioId, opt => opt.Ignore())
                .ForMember(dest => dest.Negocio, opt => opt.Ignore())
                .ForMember(dest => dest.FechaAlta, opt => opt.Ignore())
                .ForMember(dest => dest.UltimaConexion, opt => opt.Ignore());

            CreateMap<UsuarioRequest, Usuario>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Email, opt => opt.Ignore())
                .ForMember(dest => dest.Telefono, opt => opt.Ignore())
                .ForMember(dest => dest.TipoDocumento, opt => opt.Ignore())
                .ForMember(dest => dest.NumeroDocumento, opt => opt.Ignore())
                .ForMember(dest => dest.Tipo, opt => opt.Ignore())
                .ForMember(dest => dest.Activo, opt => opt.Ignore())
                .ForMember(dest => dest.FechaAlta, opt => opt.Ignore())
                .ForMember(dest => dest.NegocioId, opt => opt.Ignore())
                .ForMember(dest => dest.Negocio, opt => opt.Ignore())
                .ForMember(dest => dest.UltimoLogin, opt => opt.Ignore())
                .ForMember(dest => dest.IpUltimoLogin, opt => opt.Ignore())
                .ForMember(dest => dest.RowVersion, opt => opt.Ignore());

            // ==== Domain -> Response ====
            CreateMap<Rubro, RubroResponse>();
            CreateMap<Categoria, CategoriaResponse>();
            CreateMap<UnidadMedida, UnidadMedidaResponse>();
            CreateMap<Producto, ProductoResponse>();
            CreateMap<ProductoNegocio, ProductoNegocioResponse>();
            CreateMap<VentaDetalle, VentaDetalleResponse>();
            CreateMap<Venta, VentaResponse>();
            CreateMap<CompraDetalle, CompraDetalleResponse>();

            CreateMap<Compra, CompraResponse>()
                .ForMember(dest => dest.Detalles, opt => opt.Ignore());

            CreateMap<Cliente, ClienteResponse>();
            CreateMap<Comprobante, ComprobanteResponse>();

            CreateMap<HistoricoPrecio, HistoricoPrecioResponse>()
                .ForMember(dest => dest.PrecioAnterior, opt => opt.Ignore())
                .ForMember(dest => dest.FechaCambio, opt => opt.Ignore());

            CreateMap<HistoricoStock, HistoricoStockResponse>()
                .ForMember(dest => dest.StockAnterior, opt => opt.Ignore())
                .ForMember(dest => dest.FechaCambio, opt => opt.Ignore());

            CreateMap<Negocio, NegocioResponse>();
            CreateMap<PlanSaas, PlanSaasResponse>();
            CreateMap<Proveedor, ProveedorResponse>();
            CreateMap<Puesto, PuestoResponse>();

            CreateMap<Usuario, UsuarioResponse>()
                .ForMember(dest => dest.Puestos, opt => opt.Ignore());

            CreateMap<UsuarioPuesto, UsuarioPuestoResponse>();
        }
    }
}
