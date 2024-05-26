using ETickets.Models;

namespace ETickets.Data.Services
{
    public interface IOrdersService
    {
        Task StoreOrderAsync(List<ShoppingCartItem> shoppingCartItems, string userId, string userEmailAddress);

        Task<List<Order>> GetOrdersbyUserIdAsyn(string userId);
    }
}
