using System.Web.Mvc;

namespace QuanLyQuanAo.Areas.Salesman
{
    public class SalesmanAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Salesman";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Salesman_default",
                "Salesman/{controller}/{action}/{id}",
                new {controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}