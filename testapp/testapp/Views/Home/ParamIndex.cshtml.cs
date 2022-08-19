using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using testapp.Controllers;

namespace testapp.Views.Home
{
    public class ParamPageModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Path { get; set; } = "";

        [BindProperty(SupportsGet = true)]
        public string ApiKey { get; set; } = "";
        [BindProperty]
        public FranchiseWidgetSettingVM? Data { get; set; } = null!;
        public void OnGet(string path, string apiKey)
        {
            Path = path;
            ApiKey = apiKey;
        }
    }
}
