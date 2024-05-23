﻿using ETickets.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace ETickets.Models
{
    public class Cinema : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Logo")]
        public string Logo { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
        
        //Movie Relationship
        public List<Movie>? Movies { get; set; }
    }
}
