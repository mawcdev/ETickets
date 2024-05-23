using ETickets.Models;
using Microsoft.EntityFrameworkCore;

namespace ETickets.Data.Cart
{
    public class ShoppingCart
    {
        private readonly AppDbContext _context;

        public  string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public ShoppingCart(AppDbContext context)
        {
            _context = context;
        }

        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<AppDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddItemToCart(Movie movie)
        {
            var cartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Movie.Id == movie.Id &&
                n.ShoppingCartId == ShoppingCartId);

            if (cartItem == null)
            {
                cartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Movie = movie,
                    Amount = 1
                };

                _context.ShoppingCartItems.Add(cartItem);
            }
            else
            {
                cartItem.Amount++;
            }

            _context.SaveChanges();
        }

        public void RemoveItemFromCart(Movie movie) 
        {
            var cartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Movie.Id == movie.Id &&
            n.ShoppingCartId == ShoppingCartId);

            if (cartItem != null)
            {
                if (cartItem.Amount > 1)
                {
                    cartItem.Amount--;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(cartItem);
                }
            }

            _context.SaveChanges();
        }

        public List<ShoppingCartItem> GetShoppingCartItems() 
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems.Where(n => n.ShoppingCartId
            == ShoppingCartId).Include(n=> n.Movie).ToList());
        }

        public double GetShoppingCartTotal()=> _context.ShoppingCartItems.Where(n=>n.ShoppingCartId==ShoppingCartId).Select(n => n.Movie.Price*n.Amount).Sum();
    }
}
