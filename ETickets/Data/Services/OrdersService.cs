using ETickets.Models;
using Microsoft.EntityFrameworkCore;

namespace ETickets.Data.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly AppDbContext _appContext;

        public OrdersService(AppDbContext appContext)
        {
            _appContext = appContext;
        }
        public async Task<List<Order>> GetOrdersbyUserIdAsyn(string userId)
        {
            var orders = await _appContext.Orders.Include(n => n.OrderItems)
                                    .ThenInclude(n => n.Movie)
                                    .Where(o => o.UserId == userId)
                                    .ToListAsync();

            return orders;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> shoppingCartItems, string userId, string userEmailAddress)
        {
            var order = new Order()
            {
                UserId = userId,
                Email = userEmailAddress,
            };

            await _appContext.Orders.AddAsync(order);
            await _appContext.SaveChangesAsync();

            foreach (var item in shoppingCartItems)
            {
                var orderitems = new OrderItem()
                {
                    Amount = item.Amount,
                    MovieId = item.Movie.Id,
                    OrderId = order.Id,
                    Price = item.Movie.Price
                };

                await _appContext.OrderItems.AddAsync(orderitems);
            }
            await _appContext.SaveChangesAsync();
        }
    }
}
