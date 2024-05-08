using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting.Internal;
using MiniProjet.Models;
using MiniProjet.Models.Repositories;
using System.Collections;

namespace MiniProjet.Controllers
{
	public class FilmController : Controller
	{
		readonly IFilmRepository filmRepository;
		readonly ICinemaRepository cinemaRepository;
		readonly IWebHostEnvironment webHostEnvironment;
		public FilmController(IFilmRepository filmRepository, ICinemaRepository cinemaRepository, IWebHostEnvironment webHostEnvironment)
		{
			this.filmRepository = filmRepository;
			this.cinemaRepository = cinemaRepository;
			this.webHostEnvironment = webHostEnvironment;
		}

		// GET: FilmRepository
		public ActionResult Index()
		{
            ViewBag.Id = new SelectList(cinemaRepository.GetCinemaList(), "Id", "Name");
            var filmsList = filmRepository.GetFilmList();
			return View(filmsList);
		}

		// GET: FilmRepository/Details/5
		public ActionResult Details(int id)
		{
			var film = filmRepository.GetFilmById(id);
			return View(film);
		}

		// GET: FilmRepository/Create
		public ActionResult Create()
		{
			ViewBag.Id = new SelectList(cinemaRepository.GetCinemaList(), "Id", "Name");
			return View();
		}

		// POST: FilmRepository/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(Film film, IFormFile posterImage)
		{
			try
			{

                ViewBag.Id = new SelectList(cinemaRepository.GetCinemaList(), "Id", "Name");
                if (posterImage == null || posterImage.Length == 0)
                {
                    return View(film);
                }

                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(posterImage.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await posterImage.CopyToAsync(fileStream);
                }
				Console.WriteLine(uniqueFileName);// + uniqueFileName);
				Console.WriteLine(uploadsFolder);// + uniqueFileName);

                film.Poster = uniqueFileName;
				filmRepository.Ajouter(film);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: FilmRepository/Edit/5
		public ActionResult Edit(int id)
		{
			ViewBag.Id = new SelectList(cinemaRepository.GetCinemaList(), "Id", "Name");
			var film = filmRepository.GetFilmById(id);
			return View(film);
		}

		// POST: FilmRepository/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit(int id, Film film, IFormFile posterImage)
		{
			try
			{
                ViewBag.Id = new SelectList(cinemaRepository.GetCinemaList(), "Id", "Name");
                if (posterImage == null || posterImage.Length == 0)
                {
                    return View(film);
                }

                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(posterImage.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await posterImage.CopyToAsync(fileStream);
                }

                film.Poster = uniqueFileName;
                filmRepository.MAJ(film);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: FilmRepository/Delete/5
		public ActionResult Delete(int id)
		{
			var film = filmRepository.GetFilmById(id);
			return View(film);
		}

		// POST: FilmRepository/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, Film film)
		{
			try
			{
				filmRepository.Supprimer(film);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
        public ActionResult ChercherFilm(string title, int cinemaId)
        {
            ViewBag.Id = new SelectList(cinemaRepository.GetCinemaList(), "Id", "Name");
            var result = filmRepository.GetFilmList();
            if (!string.IsNullOrEmpty(title))
                result = filmRepository.GetFilmsByTitle(title);
            else if (cinemaId != 0) // Change to check against 0 instead of null
                result = filmRepository.GetFilmsByCinemaId(cinemaId);
            return View("Index", result);
        }
    }
}
