﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebUI.Dtos.BasketDtos;

namespace WebUI.Controllers
{
    public class BasketsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BasketsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id)
        {
            TempData["id"]=id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7027/api/Basket/BasketListByMenuTableWithProductName?id="+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBasketDto>>(jsonData); //listeleme yaptığım için Deserialize.
                return View(values);
            }
            return View();
        }    
        
        public async Task<IActionResult> DeleteBasket(int id)
        {
            id=int.Parse(TempData["id"].ToString());
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7027/api/Basket/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return NoContent();
        }
    }
}
