using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.SignalR;

namespace SignalRApi.Hubs
{
    public class SignalRHub : Hub
    {
        //bu sınıf SignalR için dağıtım görevi görecek.
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public SignalRHub(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        public async Task SendCategoryCount()
        {
            var value = _categoryService.TCategoryCount();
            await Clients.All.SendAsync("ReceiveCategoryCount", value);
        }
        public async Task SendProductCount()
        {
            var value2 = _productService.TProductCount();
            await Clients.All.SendAsync("ReceiveProductCount", value2);
        }
        public async Task ActivePassiveCategoryCount()
        {
            var value3 = _categoryService.TActiveCategoryCount();
            var value4 = _categoryService.TPassiveCategoryCount();
            await Clients.All.SendAsync("RecieveActiveCategoryCount", value3);
            await Clients.All.SendAsync("RecievePassiveCategoryCount", value4);
        }
    }
}
