using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Movie_app.Data;
using Movie_app.Models;

namespace Movie_app.Controllers
{
    public class MovieController : Controller

    {
        private readonly ApplicationDbContext _db;
        public MovieController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var movies = _db.Movies.ToList();
            return View(movies);
        }
        public IActionResult Create()
        {
            ViewData["GenresId"] = new SelectList(_db.Genres, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Movie movie)
        {
            _db.Movies.Add(movie);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Edit(int Id)
        {
            var movie = _db.Movies.Find(Id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Movie movie)
        {
            _db.Movies.Update(movie);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }



        public IActionResult Delete(int Id)
        {
            var movie = _db.Movies.Find(Id);
            return View(movie);
        }



        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int Id)
        {
            var movie = _db.Movies.Find(Id);
            if (movie != null)
            {
                _db.Movies.Remove(movie);
                _db.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

