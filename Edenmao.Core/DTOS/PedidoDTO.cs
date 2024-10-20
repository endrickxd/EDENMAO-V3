using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edenmao.Core.DTOS
{
    public class PedidoDTO
    {
        public int IdPedido { get; set; }
        [Required(ErrorMessage = "¡Este Campo es Obligatorio!")]
        public int IdCliente { get; set; }
        public decimal TotalDescuento { get; set; }
        public decimal TotalItbis { get; set; }
        public decimal Total { get; set; }
        [Required(ErrorMessage = "¡La Fecha de Registro es Obligatoria!")]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(FechaRegistrotoValidar), nameof(FechaRegistrotoValidar.ValidarFechaRegistro))]
        public DateTime FechaEmisión { get; set; }
        public string Estatus { get; set; }
    }

    public static class FechaRegistrotoValidar
    {
        public static ValidationResult ValidarFechaRegistro(DateTime fechaNacimiento, ValidationContext context)
        {
            if (fechaNacimiento < DateTime.Today)
            {
                return new ValidationResult(" ¡Ingrese una Fecha de Registro Válida!");
            }
            return ValidationResult.Success;
        }
    }
}
