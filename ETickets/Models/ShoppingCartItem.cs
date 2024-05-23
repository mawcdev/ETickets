using System.ComponentModel.DataAnnotations;

namespace ETickets.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }
        public Movie Movie { get; set; }
        public int Amount { get; set; }
        //public double Price { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
