using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Movie.Data;
using Movie.Extensions;
using Movie.Models;
using Movie.Models.ViewModels;

namespace Movie.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieContext db;

        public MoviesController(MovieContext context)
        {
            db = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            return View(await db.Movie.ToListAsync());
        }  
        
        public async Task<IActionResult> Index2()
        {
            var movies = await db.Movie.ToListAsync();
            var model = new MovieViewModel
            {
                Movies = movies,
                Genres = await GetGenresAsync()
            };

            return View(model);
        }   
        
        public async Task<IActionResult> Index3()
        {
            var movies = await db.Movie.ToListAsync();
            var model = new MovieViewModel2
            {
                Movies = movies,
            };

            return View(model);
        }

        private async Task<IEnumerable<SelectListItem>> GetGenresAsync()
        {
            return await db.Movie
                          .Select(m => m.Genre)
                          .Distinct()
                          .Select(g => new SelectListItem
                          {
                              Text = g.ToString(),
                              Value = g.ToString()
                          })
                          .ToListAsync();
        }

        public async Task<IActionResult> Filter(string title, int? genre)
        {
            var model = string.IsNullOrWhiteSpace(title) ?
                db.Movie :
                db.Movie.Where(m => m.Title.StartsWith(title));

            model = genre == null ?
                model :
                model.Where(m => (int)m.Genre == genre);

            return View(nameof(Index), await model.ToListAsync());

        }  
        
        public async Task<IActionResult> Filter2(MovieViewModel viewModel)
        {
            var movies = string.IsNullOrWhiteSpace(viewModel.Title) ?
                db.Movie :
                db.Movie.Where(m => m.Title.StartsWith(viewModel.Title));

            movies = viewModel.Genre == null ?
                movies :
                movies.Where(m => m.Genre == viewModel.Genre);

            var model = new MovieViewModel
            {
                Movies = movies,
                Genres = await GetGenresAsync()
            };

            return View(nameof(Index2), model);

        } 
        
        public IActionResult Filter3(MovieViewModel2 viewModel)
        {
            var movies = string.IsNullOrWhiteSpace(viewModel.Title) ?
                db.Movie :
                db.Movie.Where(m => m.Title.StartsWith(viewModel.Title));

            movies = viewModel.Genre == null ?
                movies :
                movies.Where(m => m.Genre == viewModel.Genre);

            var model = new MovieViewModel2
            {
                Movies = movies,
            };

            return View(nameof(Index3), model);

        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await db.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Rating")] MovieModel movie)
        {
            if (ModelState.IsValid)
            {
                db.Add(movie);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await db.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Rating")] MovieModel movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(movie);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await db.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await db.Movie.FindAsync(id);
            db.Movie.Remove(movie);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return db.Movie.Any(e => e.Id == id);
        }
    }
}
