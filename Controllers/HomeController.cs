using Microsoft.AspNetCore.Mvc;
using Mission11_JacobBigler.Models;
using Mission11_JacobBigler.Models.ViewModels;
using System.Diagnostics;

namespace Mission11_JacobBigler.Controllers
{
    public class HomeController : Controller
    {

        private IBookstoreRepository _repo;

        public HomeController(IBookstoreRepository temp)
        {
            _repo = temp;
        }


        public IActionResult Index(int pageNum)
        {
            int pageSize = 10;

            var vm = new BooksListViewModel
            {
                Books = _repo.Books
                .OrderBy(x => x.Title)
                .Skip(pageSize * (pageNum - 1))
                .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = _repo.Books.Count()
                }
            };

            return View(vm);
        }

    }
}
