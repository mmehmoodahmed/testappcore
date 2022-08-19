using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using testapp.Models;
using testapp.Views.Home;

namespace testapp.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;     
        private readonly IConfiguration Configuration;
        public HomeController(IConfiguration configuration, ILogger<HomeController> logger)
        {
            _logger = logger;            
            Configuration = configuration;         
        }

        public /*async Task<*/FranchiseWidgetSettingVM?/*>*/ FindFranchiseWidgetSettings(int franchiseId = 0, int id = 0, string apiKey = "", 
            string websiteUrl = "", string customApiUrl = "")
        {
            try
            {
                List<FranchiseWidgetSettingVM> frList = new List<FranchiseWidgetSettingVM>();
                frList.Add(new FranchiseWidgetSettingVM { ApiKey = "1211a",FranchiseId = 1231, FranchiseName="Fr1",CustomApiUrl= "/custom/contact/" });
                frList.Add(new FranchiseWidgetSettingVM { ApiKey = "1212a", FranchiseId = 1232, FranchiseName = "Fr2", CustomApiUrl = "/locations/england/southwest/exmouth/" });
                frList.Add(new FranchiseWidgetSettingVM { ApiKey = "1213a", FranchiseId = 1233, FranchiseName = "Fr3", CustomApiUrl = "/custom/contact/" });
                frList.Add(new FranchiseWidgetSettingVM { ApiKey = "1214a", FranchiseId = 1234, FranchiseName = "Fr4", CustomApiUrl = "/custom/contact/" });

                List<FranchiseWidgetSettingVM> res = frList; // await dbContent.Franchises.ToListAsync();
                return res.FirstOrDefault();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
                //  throw ex;
            }
        }


        public async Task<IActionResult> ParamIndex(string path = "/locations/england/southwest/exmouth/", string apiKey = "")
        {
            ViewBag.SrvDtTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            int franchiseId = 0;
            int.TryParse(apiKey, out franchiseId);
            FranchiseWidgetSettingVM? windgetSetting = null;
            if (!string.IsNullOrWhiteSpace(path) || !string.IsNullOrWhiteSpace(apiKey))
            {
                windgetSetting = /*await*/ FindFranchiseWidgetSettings(franchiseId, 0, apiKey, string.Empty, path);
            }
            windgetSetting = (windgetSetting != null ? windgetSetting : new FranchiseWidgetSettingVM());
            ParamPageModel item = new ParamPageModel() { ApiKey = apiKey, Path = path, Data = windgetSetting };
            return Redirect("parambooking/?path=" + item.Path + "&apikey=" + item.ApiKey);          
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class FranchiseWidgetSettingVM
    {
        public int Id { get; set; }
        public int FranchiseId { get; set; }
        public string? FranchiseName { get; set; }
        public string ApiKey { get; set; } = null!;
        public string WebSiteUrl { get; set; } = null!;
        public string CustomApiUrl { get; set; } = null!;
        public short StatusId { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string? TransactionType { get; set; }
        public DateTime? InsertedDate { get; set; }
        public int? InsertedUserId { get; set; }
        public string? InsertedUserName { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdateUserId { get; set; }
        public string? UpdatedUserName { get; set; }

    }
}