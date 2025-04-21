using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class DomainToDtoProfile:Profile
    {
        public DomainToDtoProfile()
        
        {
            //cada entidad se se pasa a DTOs y viseversa
            // Catálogos
            CreateMap<Domain.Entities.Rubro, DTOs.RubroDto>().ReverseMap();
            CreateMap<Domain.Entities.Categoria, DTOs.CategoriaDto>().ReverseMap();
            CreateMap<Domain.Entities.UnidadMedida, DTOs.UnidadMedidaDto>().ReverseMap();

            // Productos e inventario
            CreateMap<Domain.Entities.Producto, DTOs.ProductoDto>().ReverseMap();
            CreateMap<Domain.Entities.ProductoNegocio, DTOs.ProductoNegocioDto>().ReverseMap();

            // Transacciones
            CreateMap<Domain.Entities.Venta, DTOs.VentaDto>().ReverseMap();
            CreateMap<Domain.Entities.VentaDetalle, DTOs.VentaDetalleDto>().ReverseMap();
            CreateMap<Domain.Entities.Compra, DTOs.CompraDto>().ReverseMap();
            CreateMap<Domain.Entities.CompraDetalle, DTOs.CompraDetalleDto>().ReverseMap();
            CreateMap<Domain.Entities.Comprobante, DTOs.ComprobanteDto>().ReverseMap();

            // Clientes y proveedores
            CreateMap<Domain.Entities.Cliente, DTOs.ClienteDto>().ReverseMap();
            CreateMap<Domain.Entities.Proveedor, DTOs.ProveedorDto>().ReverseMap();
            

            // Negocio y plan SaaS
            CreateMap<Domain.Entities.Negocio, DTOs.NegocioDto>().ReverseMap();
            CreateMap<Domain.Entities.PlanSaas, DTOs.PlanSaasDto>().ReverseMap();

            // Puestos y Usuarios
            CreateMap<Domain.Entities.Puesto, DTOs.PuestoDto>().ReverseMap();
            CreateMap<Domain.Entities.Usuario, DTOs.UsuarioDto>().ReverseMap();

            // Históricos
            CreateMap<Domain.Entities.HistoricoPrecio, DTOs.HistoricoPrecioDto>().ReverseMap();
            CreateMap<Domain.Entities.HistoricoStock, DTOs.HistoricoStockDto>().ReverseMap();



        }
    }
}
