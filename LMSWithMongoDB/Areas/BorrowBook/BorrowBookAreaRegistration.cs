using System.Web.Mvc;

namespace LMSWithMongoDB.Areas.BorrowBook
{
    public class BorrowBookAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "BorrowBook";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "BorrowBook_default",
                "BorrowBook/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}