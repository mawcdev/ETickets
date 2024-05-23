using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ETickets.Data.Base;
using ETickets.Data.Enums;

namespace ETickets.Models
{
    public class NewMovieVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required!")]
        [Display(Name="Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required!")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required!")]
        [Display(Name = "Price")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Image is required!")]
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Start date is required!")]
        [Display(Name = "Movie Start Date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is required!")]
        [Display(Name = "Movie End Date")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Category is required!")]
        [Display(Name = "Select a category")]
        public MovieCategory MovieCategory { get; set; }

        //Relationships
        [Required(ErrorMessage = "Movie Actor(s) is required!")]
        [Display(Name = "Select Actor(s)")]
        public List<int> ActorIds { get; set; }

        //Foreign key
        [Required(ErrorMessage = "Cinema is required!")]
        [Display(Name = "Select Cinema")]
        public int CinemaId { get; set; }

        [Required(ErrorMessage = "Producer is required!")]
        [Display(Name = "Select Producer")]
        public int ProducerId { get; set; }
    }
}
