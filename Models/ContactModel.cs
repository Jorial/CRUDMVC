using System.ComponentModel.DataAnnotations;
namespace CRUDMVC.Models
{
    public class ContactModel
    {
        public int Idcontacto { get; set; }
            
        [Required(ErrorMessage = "El campo nombre es obligatorio")]
        //[StringLength(8, ErrorMessage = "El Numero Telefonico debe tener un Max de 8 caracteres")]
        [MinLength(4, ErrorMessage = "El Nombre  debe contener minimo 4 caracteres")]
        [MaxLength(25, ErrorMessage = "El Nombre  debe contener minimo 10 caracteres")]
        public string? Nombre { get; set; }

        [Required (ErrorMessage ="El campo Telefono es obligatorio")] [Display(Name = "Telefono")]      
        public int? Telefono { get; set; }

    }
}
