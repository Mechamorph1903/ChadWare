using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChadWare.Controllers
{
    public class OrderController
    {
        readonly IDataService _data;
        public OrderController(IDataService dataService) => _data = dataService;

        public Task PlaceOrderAsync(Order order)
            => _data.PlaceOrderAsync(order);

        public async Task CompleteOrderAsync(Page fromPage, Order order)
        {
            await PlaceOrderAsync(order);
            await fromPage.DisplayAlert("Success", "Your order has been placed!", "OK");
            await fromPage.Navigation.PopToRootAsync();
        }
    }
}
