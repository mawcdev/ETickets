using ETickets.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace ETickets.Models
{
    public class Actor : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Profile Picture")]
        [Required(ErrorMessage ="Profile Picture is required!")]
        public string ProfilePictureUrl { get; set; }

        [Display(Name ="Full Name")]
        [Required(ErrorMessage = "Full name is required!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full name must be between 3 and 50 characters!")]
        public string FullName { get; set; }

        [Display(Name ="Biography")]
        [Required(ErrorMessage = "Biography is required!")]
        public string Bio { get; set; }

        //Relationship
        public List<Actor_Movie>? Actors_Movies { get; set; }
    }
}
