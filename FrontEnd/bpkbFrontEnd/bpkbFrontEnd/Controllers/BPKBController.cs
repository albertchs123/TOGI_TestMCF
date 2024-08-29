using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text;
using bpkbFrontEnd.Models;
using System.Text.Json;

namespace bpkbFrontEnd.Controllers
{
    public class BPKBController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BPKBController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            var response = await client.GetStringAsync("https://localhost:7134/api/Bpkbs");
            var bpkbs = JsonSerializer.Deserialize<List<BPKBModel>>(response);

            return View(bpkbs);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BPKBModel bpkb)
        {
            var vals = new BPKBval
            {
               agreement_number = bpkb.agreement_number,
               bpkb_no = bpkb.bpkb_no,
               branch_id = bpkb.branch_id,
               bpkb_date = bpkb.bpkb_date,
               faktur_no = bpkb.faktur_no,
               faktur_date = bpkb.faktur_date,
               location_id = bpkb.location_id,
               police_no = bpkb.police_no,
               bpkb_date_in = bpkb.bpkb_date_in,
               user = "admin"
            };

            var client = _httpClientFactory.CreateClient("ApiClient");
            var content = new StringContent(
                JsonSerializer.Serialize(vals),
                Encoding.UTF8,
                "application/json"
            );

            var response = await client.PostAsync("Bpkbs", content);

            if (response.IsSuccessStatusCode == false)
            {
                return View();
            }

            return RedirectToAction("Index", "BPKB");
        }

    }
}
