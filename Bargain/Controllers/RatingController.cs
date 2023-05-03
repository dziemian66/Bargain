using Microsoft.AspNetCore.Mvc;

namespace Bargain.Web.Controllers
{
    public class RatingController : Controller
    {
        public IActionResult Like(int UserId, int ItemId)
        {
            //Opracować po dodaniu użytkowników
            return new EmptyResult();
        }
        public IActionResult Unlike(int UserId, int ItemId)
        {
            //Opracować po dodaniu użytkowników
            return new EmptyResult();
        }

    }
}
