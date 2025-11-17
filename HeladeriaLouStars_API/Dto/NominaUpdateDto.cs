using System.ComponentModel.DataAnnotations;

namespace HeladeriaLouStars_API.Dto
{
    public class NominaUpdateDto
    {
        public int NominaID { get; set; }
        public int AdministradorID { get; set; }
        [Required(ErrorMessage = "El campo EmpleadoID es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El EmpleadoID debe ser mayor que cero.")]
        public int EmpleadoID { get; set; }


        [Required(ErrorMessage = "fecha obligatoria.")]
        public DateTime Periodo { get; set; }


        [Required(ErrorMessage = "Espacio obligatorio.")]

        public decimal SalarioDevengado { get; set; }

        public decimal Bonificaciones { get; set; }
        public decimal HorasExtra { get; set; }
        public decimal Antiguedad { get; set; }

        public decimal PagoHorasExtra => HorasExtra * (SalarioDevengado / (30m * 8m)) * 1.5m;
        public decimal PagoAntiguedad => Antiguedad * 20m;

        public decimal TotalIngresos
        {
            get
            {
                return (SalarioDevengado + PagoHorasExtra + PagoAntiguedad + Bonificaciones);
            }
            set
            {
            }
        }

        public decimal InssLaboral
        {
            get
            {
                return TotalIngresos * 0.07m;
            }
            set
            {
            }
        }

        public decimal IR
        {
            get
            {
                return TotalIngresos * 0.20m;
            }
            set
            {
            }
        }

        public decimal Deducciones
        {
            get
            {
                return InssLaboral + IR;
            }
            set
            {
            }
        }

        public decimal SalarioNeto
        {
            get
            {
                return TotalIngresos - Deducciones;
            }
            set
            {
            }
        }
    }
}
