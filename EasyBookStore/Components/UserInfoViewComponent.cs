using Microsoft.AspNetCore.Mvc;

namespace EasyBookStore.Components
{
    public class UserInfoViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            if (User.Identity?.IsAuthenticated == true)
                return View("UserInfo");
            return View();
        }
    }
}
