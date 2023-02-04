using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace arabi2.Controllers
{
    
    public class ProductController : Controller
    {

        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {
            string Authorization = "f44a4aabfc5992514d262d7f517327e7";
            string StoreID = "4";
            string UserAddressID = "60877";
            string url = "https://api.manoapp.com/api/v1/users/products/whats_new";

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                httpClient.DefaultRequestHeaders.Add("StoreId", StoreID);
                httpClient.DefaultRequestHeaders.Add("Authorization", Authorization);
                httpClient.DefaultRequestHeaders.Add("UserAddressID", UserAddressID);
                HttpResponseMessage response = await httpClient.GetAsync(url);
                string responseBody = await response.Content.ReadAsStringAsync();
                var responseJson = JsonConvert.DeserializeObject<dynamic>(responseBody);
                var allItems = ((Newtonsoft.Json.Linq.JArray)responseJson.data.items).Select(i => (dynamic)i).ToList();
                ViewData["items"] = allItems;
                var itemCount = allItems.Count();
                var pageCount = (int)Math.Ceiling(itemCount / (double)pageSize);

                var result = allItems
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                ViewData["Page"] = page;
                ViewData["PageCount"] = pageCount;
                ViewData["PageSize"] = pageSize;
                ViewData["items"] = result;

                return View();

            }

            
        }

     
    }
}