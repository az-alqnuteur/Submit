using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Test_code_frest.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Invalid")]
        [Index (IsUnique = true)]
        [Column(TypeName ="VARCHAR")]
        [Display(Name = "User Name")]
        public string UserNamr { get; set; }
        [Required(ErrorMessage = "Invalid")]
        [MinLength(8)]
        [DataType(DataType.Password)]
        [Display(Name = "Enter the Code")]
        public string UserPass { get; set; }
        [Required(ErrorMessage = "Invalid")]
        [Display(Name = "User Email")]
        public string UserEmail { get; set; }
        [Display(Name = "User Details")]
        public string UserDetails { get; set; }

       
        
       
    }
}