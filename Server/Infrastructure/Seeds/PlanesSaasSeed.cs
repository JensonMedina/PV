using Domain.Entities;
using Domain.Enum;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Seeds
{
    public static class PlanesSaasSeed
    {
        public static void SeedPlanesSaas(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlanSaas>().HasData(
                new PlanSaas
                {
                    Id = 1,
                    Nombre = "Plan Básico",
                    Descripcion = "Para pequeños negocios o emprendimientos.",
                    Costo = 5000,
                    Periodo = Periodo.Mensual,
                    LimiteUsuarios = 2,
                    LimiteProductos = 1000,
                },
                new PlanSaas
                {
                    Id = 2,
                    Nombre = "Plan Profesional",
                    Descripcion = "Para negocios medianos.",
                    Costo = 7000,
                    Periodo = Periodo.Mensual,
                    LimiteUsuarios = 5,
                    LimiteProductos = 1200,
                },
                new PlanSaas
                {
                    Id = 3,
                    Nombre = "Plan Premium",
                    Descripcion = "Para negocios grandes o cadenas de tiendas.",
                    Costo = 8000,
                    Periodo = Periodo.Mensual
                }
            );
        }
    }
}
