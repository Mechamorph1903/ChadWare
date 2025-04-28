using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChadWare.Models;
using ChadWare.Services;

namespace ChadWare.Controllers
{
    public class CartController
    {
        readonly IDataService _data;
        public CartController(IDataService dataService) => _data = dataService;

        public Task<List<CartItem>> GetCartAsync(long userId)
            => _data.GetCartAsync(userId);

        public Task AddToCartAsync(long userId, CartItem item)
            => _data.AddToCartAsync(userId, item);

        public Task RemoveFromCartAsync(long userId, long cartItemId)
            => _data.RemoveFromCartAsync(userId, cartItemId);

        public async Task NavigateToCheckoutAsync(Page fromPage, long userId)
        {
            var items = await GetCartAsync(userId);
            await fromPage.Navigation.PushAsync(
                new Views.Pages.CheckoutPage(userId, items)
            );
        }
    }

}
