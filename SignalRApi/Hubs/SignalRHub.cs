using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.SignalR;

namespace SignalRApi.Hubs
{
    public class SignalRHub : Hub
    {
        //bu sınıf SignalR için dağıtım görevi görecek.
        Context context = new Context();

        public async Task SendCategoryCount()
        {
            var value = context.Categories.Count();
            await Clients.All.SendAsync("ReceiveCategoryCount", value);
        }
    }
}
