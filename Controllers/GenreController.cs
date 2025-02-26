using Humanizer.Localisation;
using Microsoft.AspNetCore.Mvc;
using Movie_app.Data;
using Movie_app.Models;

namespace Movie_app.Controllers
{
    public class GenreController : Controller
    {
        private readonly ApplicationDbContext _db;
        public GenreController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var genres = _db.Genres.ToList();
            return View(genres);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Genre genre)
        {
            if (ModelState.IsValid)
            {
                _db.Genres.Add(genre);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(genre);
        }

        public IActionResult Edit(Guid Id)
        {
            var genre = _db.Genres.Find(Id);
            if (genre == null)
            {
                return NotFound();
            }
            return View(genre);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Genre genre)
        {
            if (ModelState.IsValid)
            {
                _db.Genres.Update(genre);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(genre);
        }

        public IActionResult Delete(Guid Id)
        {
            var genre = _db.Genres.Find(Id);
            if (genre == null)
            {
                return NotFound();
            }
            return View(genre);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid Id)
        {
            var genre = _db.Genres.Find(Id);
            if (genre != null)
            {
                _db.Genres.Remove(genre);
                _db.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
