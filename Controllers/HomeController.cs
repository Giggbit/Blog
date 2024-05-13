using Blog.Interfaces;
using Blog.Models;
using Blog.Models.Pages;
using Blog.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategory _categories;
        private readonly IPublication _publications;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ISubscriber _subscriber;

        public HomeController(ICategory categories, IPublication publications, IWebHostEnvironment webHostEnvironment, ISubscriber subscriber)
        {
            _categories = categories;
            _publications = publications;
            _webHostEnvironment = webHostEnvironment;
            _subscriber = subscriber;
        }

        public async Task<IActionResult> Index(QueryOptions? options, string? categoryId) { 
            var allCategories = await _categories.GetAllCategoriesAsync();
            var allPublications = await _publications.GetAllPublicationsByCategoryWithCAtegories(options, categoryId);

            return View(new IndexViewModel
            {
                Categories = allCategories.ToList(),
                Publications = allPublications
            });
        }

        [Route("publication")]
        public async Task<IActionResult> GetPublication(string? id, string? returnUrl) {
            var currentPublication = await _publications.GetPublicationWithCategoriesAsync(id);
            if (currentPublication != null) {
                await _publications.UpdateViewAsync(currentPublication.Id.ToString());
                return View( new GetPublicationViewModel 
                {
                    Publication = currentPublication,
                    ReturnUrl = returnUrl
                });
            }
            return NotFound();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Subscribe(string email) { 
            if(!await _subscriber.IsSubscribe(email)) {
                await _subscriber.Subscribe(new Subscriber
                {
                    Email = email
                });
                return Content("Подписка оформлена успешно!");
            }
            else { 
                return Content("Вы уже оформили подписку!");
            }
        }


    }
}
