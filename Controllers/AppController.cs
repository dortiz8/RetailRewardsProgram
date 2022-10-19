using Microsoft.AspNetCore.Mvc;
using RetailRewardsProgram.Data;
using System.Linq;

namespace RetailRewardsProgram.Controllers
{
    public class AppController : Controller
    {
        public IUserRepository _repo { get; }

        public AppController(UserContext context, IUserRepository repo)
        {
            _repo = repo; 
        }
        public IActionResult Index()
        {
            var users = _repo.GetAllUsersAndTheirPurchases();  

            return View(users);
        }
        [Route("App/Details/{id:int}")]
        public IActionResult Details(int Id)
        {
            
            ViewBag.Title = "Details for " + Id;
            var user = _repo.GetUserById(Id); 
            return View(user); 
        }
    }
}
