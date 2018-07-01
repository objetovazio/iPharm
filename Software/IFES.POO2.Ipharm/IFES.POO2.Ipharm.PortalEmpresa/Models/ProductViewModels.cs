using System;
using System.ComponentModel.DataAnnotations;

namespace IFES.POO2.Ipharm.PortalEmpresa.Models
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Nome do Produto")]
        public string Name { get; set; }

        [Display(Name = "Preço")]
        public decimal Value { get; set; }

        [Display(Name = "Medicamento Controlado")]
        public bool HasControl { get; set; }

        [Display(Name = "Ativo")]
        public bool IsDeleted { get; set; }
    }

    public class ProductDetailsViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Nome do Produto")]
        public string Name { get; set; }

        [Display(Name = "Preço")]
        public decimal Value { get; set; }

        [Display(Name = "Medicamento Controlado")]
        public bool HasControl { get; set; }

        [Display(Name = "Ativo")]
        public bool IsDeleted { get; set; }

        [Display(Name = "Descrição do Produto")]
        public string Description { get; set; }
    }

    public class ProductEditViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "O {0} deve conter entre {2} e {1} caracteres.", MinimumLength = 6)]
        [Display(Name = "Nome do Produto")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Preço")]
        public decimal Value { get; set; }

        [Required]
        [StringLength(300, ErrorMessage = "A {0} deve conter entre {2} e {1} caracteres.", MinimumLength = 20)]
        [Display(Name = "Descrição do Produto")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Medicamento Controlado")]
        public bool HasControl { get; set; }

        [Required]
        [Display(Name = "Excluir")]
        public bool IsDeleted { get; set; }
    }

    public class ProductCreateViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "O {0} deve conter entre {2} e {1} caracteres.", MinimumLength = 6)]
        [Display(Name = "Nome do Produto")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Preço")]
        public decimal Value { get; set; }

        [Required]
        [StringLength(300, ErrorMessage = "A {0} deve conter entre {2} e {1} caracteres.", MinimumLength = 20)]
        [Display(Name = "Descrição do Produto")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Medicamento Controlado")]
        public bool HasControl { get; set; }

        [Required]
        [Display(Name = "Excluir")]
        public bool IsDeleted { get; set; }
    }


}