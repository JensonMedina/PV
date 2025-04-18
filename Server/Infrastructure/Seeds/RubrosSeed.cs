using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Seed
{
    public static class RubrosSeed
    {
        public static void SeedRubros(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rubro>().HasData(
                new Rubro
                {
                    Id = 1,
                    Nombre = "Alimentos y Bebidas",
                    Descripcion = "Productos comestibles, bebidas alcohólicas y no alcohólicas",
                    Activo = true,
                    FechaAlta = DateTime.Now
                },
                new Rubro
                {
                    Id = 2,
                    Nombre = "Electrodomésticos",
                    Descripcion = "Artículos eléctricos para el hogar",
                    Activo = true,
                    FechaAlta = DateTime.Now
                },
                new Rubro
                {
                    Id = 3,
                    Nombre = "Indumentaria",
                    Descripcion = "Ropa y accesorios de moda",
                    Activo = true,
                    FechaAlta = DateTime.Now
                },
                new Rubro
                {
                    Id = 4,
                    Nombre = "Limpieza",
                    Descripcion = "Productos de higiene y limpieza",
                    Activo = true,
                    FechaAlta = DateTime.Now
                },
                new Rubro
                {
                    Id = 5,
                    Nombre = "Ferretería",
                    Descripcion = "Herramientas y artículos de construcción",
                    Activo = true,
                    FechaAlta = DateTime.Now
                },
                new Rubro
                {
                    Id = 6,
                    Nombre = "Tecnología",
                    Descripcion = "Equipos informáticos, celulares, accesorios",
                    Activo = true,
                    FechaAlta = DateTime.Now
                }
            );

        }
    }
}
