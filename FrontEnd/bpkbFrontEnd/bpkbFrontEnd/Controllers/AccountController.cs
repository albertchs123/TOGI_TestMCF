using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text;
using bpkbFrontEnd.Models;
using System.Text.Json;

namespace bpkbFrontEnd.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AccountController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var vals = new RegisterVal
            {
                user_name = model.UserName,
                password = model.Password,
            };

            var client = _httpClientFactory.CreateClient("ApiClient");
            var content = new StringContent(
                JsonSerializer.Serialize(vals),
                Encoding.UTF8,
                "application/json"
            );

            var response = await client.PostAsync("Users/login", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var loginResponse = JsonSerializer.Deserialize<ReturnStatusLogin>(responseContent);

                if (loginResponse != null && loginResponse.isSuccess)
                {
                    return RedirectToAction("Index", "BPKB");
                }
                else
                {
                    ModelState.AddModelError("", loginResponse?.message ?? "Login gagal.");
                }
            }
            else
            {
                ModelState.AddModelError("", "Login gagal. Coba lagi.");
            }

            return View(model);
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var vals = new RegisterVal
            {
                user_name = model.UserName,
                password = model.Password,
            };

            var client = _httpClientFactory.CreateClient("ApiClient");
            var content = new StringContent(
                JsonSerializer.Serialize(vals),
                Encoding.UTF8,
                "application/json"
            );

            var response = await client.PostAsync("Users/register", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Login");
            }

            return View(model);
        }


    }
}
