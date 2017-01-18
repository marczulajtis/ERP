using System.Web.Mvc;

namespace ERP.Areas.Menu
{
    public class MenuAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Menu";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Menu_default",
                "Menu/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}