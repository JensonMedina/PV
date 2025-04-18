using Domain.Entities;
using Domain.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Seeds
{
    public static class UnidadesMedidasSeed
    {
        public static void SeedUnidadesMedidas(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UnidadMedida>().HasData(
               new UnidadMedida { Id = 1, Nombre = "Unidad", Abreviatura = "u", TipoUnidadMedida = TipoUnidadMedida.Unidad, Activo = true },
               new UnidadMedida { Id = 2, Nombre = "Par", Abreviatura = "pr", TipoUnidadMedida = TipoUnidadMedida.Par, Activo = true },
               new UnidadMedida { Id = 3, Nombre = "Docena", Abreviatura = "dz", TipoUnidadMedida = TipoUnidadMedida.Docena, Activo = true },
               new UnidadMedida { Id = 4, Nombre = "Gramo", Abreviatura = "g", TipoUnidadMedida = TipoUnidadMedida.Gramo, Activo = true },
               new UnidadMedida { Id = 5, Nombre = "Kilogramo", Abreviatura = "kg", TipoUnidadMedida = TipoUnidadMedida.Kilogramo, Activo = true },
               new UnidadMedida { Id = 6, Nombre = "Miligramo", Abreviatura = "mg", TipoUnidadMedida = TipoUnidadMedida.Miligramo, Activo = true },
               new UnidadMedida { Id = 7, Nombre = "Tonelada", Abreviatura = "t", TipoUnidadMedida = TipoUnidadMedida.Tonelada, Activo = true },
               new UnidadMedida { Id = 8, Nombre = "Mililitro", Abreviatura = "ml", TipoUnidadMedida = TipoUnidadMedida.Mililitro, Activo = true },
               new UnidadMedida { Id = 9, Nombre = "Litro", Abreviatura = "l", TipoUnidadMedida = TipoUnidadMedida.Litro, Activo = true },
               new UnidadMedida { Id = 10, Nombre = "Metro Cúbico", Abreviatura = "m³", TipoUnidadMedida = TipoUnidadMedida.MetroCubico, Activo = true },
               new UnidadMedida { Id = 11, Nombre = "Centímetro Cúbico", Abreviatura = "cm³", TipoUnidadMedida = TipoUnidadMedida.CentimetroCubico, Activo= true },
               new UnidadMedida { Id = 12, Nombre = "Milímetro", Abreviatura = "mm", TipoUnidadMedida = TipoUnidadMedida.Milimetro, Activo = true },
               new UnidadMedida { Id = 13, Nombre = "Centímetro", Abreviatura = "cm", TipoUnidadMedida = TipoUnidadMedida.Centimetro, Activo = true },
               new UnidadMedida { Id = 14, Nombre = "Metro", Abreviatura = "m", TipoUnidadMedida = TipoUnidadMedida.Metro, Activo = true },
               new UnidadMedida { Id = 15, Nombre = "Kilómetro", Abreviatura = "km", TipoUnidadMedida = TipoUnidadMedida.Kilometro, Activo = true },
               new UnidadMedida { Id = 16, Nombre = "Metro Cuadrado", Abreviatura = "m²", TipoUnidadMedida = TipoUnidadMedida.MetroCuadrado, Activo = true },
               new UnidadMedida { Id = 17, Nombre = "Centímetro Cuadrado", Abreviatura = "cm²", TipoUnidadMedida = TipoUnidadMedida.CentimetroCuadrado, Activo = true },
               new UnidadMedida { Id = 18, Nombre = "Minuto", Abreviatura = "min", TipoUnidadMedida = TipoUnidadMedida.Minuto, Activo = true },
               new UnidadMedida { Id = 19, Nombre = "Hora", Abreviatura = "h", TipoUnidadMedida = TipoUnidadMedida.Hora, Activo = true },
               new UnidadMedida { Id = 20, Nombre = "Día", Abreviatura = "d", TipoUnidadMedida = TipoUnidadMedida.Dia, Activo = true },
               new UnidadMedida { Id = 21, Nombre = "Semana", Abreviatura = "sem", TipoUnidadMedida = TipoUnidadMedida.Semana, Activo = true },
               new UnidadMedida { Id = 22, Nombre = "Mes", Abreviatura = "mes", TipoUnidadMedida = TipoUnidadMedida.Mes, Activo = true },
               new UnidadMedida { Id = 23, Nombre = "Caja", Abreviatura = "caja", TipoUnidadMedida = TipoUnidadMedida.Caja, Activo = true },
               new UnidadMedida { Id = 24, Nombre = "Paquete", Abreviatura = "paq", TipoUnidadMedida = TipoUnidadMedida.Paquete, Activo = true },
               new UnidadMedida { Id = 25, Nombre = "Blíster", Abreviatura = "blst", TipoUnidadMedida = TipoUnidadMedida.Blister, Activo = true },
               new UnidadMedida { Id = 26, Nombre = "Frasco", Abreviatura = "fras", TipoUnidadMedida = TipoUnidadMedida.Frasco, Activo = true },
               new UnidadMedida { Id = 27, Nombre = "Rollo", Abreviatura = "rll", TipoUnidadMedida = TipoUnidadMedida.Rollo, Activo = true },
               new UnidadMedida { Id = 28, Nombre = "Tira", Abreviatura = "tira", TipoUnidadMedida = TipoUnidadMedida.Tira, Activo = true },
               new UnidadMedida { Id = 29, Nombre = "Servicio", Abreviatura = "serv", TipoUnidadMedida = TipoUnidadMedida.Servicio, Activo = true },
               new UnidadMedida { Id = 30, Nombre = "Megabyte", Abreviatura = "MB", TipoUnidadMedida = TipoUnidadMedida.Megabyte, Activo = true },
               new UnidadMedida { Id = 31, Nombre = "Gigabyte", Abreviatura = "GB", TipoUnidadMedida = TipoUnidadMedida.Gigabyte, Activo = true },
               new UnidadMedida { Id = 32, Nombre = "Terabyte", Abreviatura = "TB", TipoUnidadMedida = TipoUnidadMedida.Terabyte, Activo = true }
           );


        }
    }
}
