using System;
using System.ComponentModel.DataAnnotations;

namespace IFES.POO2.Ipharm.PortalEmpresa.Models
{
    public class ProductViewModels
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "O {0} deve conter entre {2} e {1} caracteres.", MinimumLength = 6)]
        [Display(Name = "Nome do Produto")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Preço")]
        public decimal Value { get; set; }

        [Required]
        [StringLength(300, ErrorMessage = "A {0} deve conter entre {2} e {1} caracteres.", MinimumLength = 50)]
        [Display(Name = "Descrição do Produto")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Medicamento Controlado")]
        public bool HasControl { get; set; }
    }
}