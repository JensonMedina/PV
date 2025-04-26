using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Seeds
{
    public static class RubrosSeed
    {
        public static void SeedRubros(this ModelBuilder modelBuilder)
        {
            var fechaFija = new DateTime(2025, 4, 25);
            modelBuilder.Entity<Rubro>().HasData(
                new Rubro
                {
                    Id = 1,
                    Nombre = "Alimentos y Bebidas",
                    Descripcion = "Productos comestibles, bebidas alcohólicas y no alcohólicas",
                    FechaAlta = fechaFija
                },
                new Rubro
                {
                    Id = 2,
                    Nombre = "Electrodomésticos",
                    Descripcion = "Artículos eléctricos para el hogar",
                    FechaAlta = fechaFija
                },
                new Rubro
                {
                    Id = 3,
                    Nombre = "Indumentaria",
                    Descripcion = "Ropa y accesorios de moda",
                    FechaAlta = fechaFija
                },
                new Rubro
                {
                    Id = 4,
                    Nombre = "Limpieza",
                    Descripcion = "Productos de higiene y limpieza",
                    FechaAlta = fechaFija
                },
                new Rubro
                {
                    Id = 5,
                    Nombre = "Ferretería",
                    Descripcion = "Herramientas y artículos de construcción",
                    FechaAlta = fechaFija
                },
                new Rubro
                {
                    Id = 6,
                    Nombre = "Tecnología",
                    Descripcion = "Equipos informáticos, celulares, accesorios",
                    FechaAlta = fechaFija
                }
            );

        }
    }
}
