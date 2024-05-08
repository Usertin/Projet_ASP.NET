using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniProjet.Models;
using MiniProjet.Models.Repositories;
using MiniProjet.ViewModels;

namespace MiniProjet.Controllers
{
	[Authorize]
	public class CinemaController : Controller
	{
		readonly ICinemaRepository cinemaRepository;
		readonly IFilmRepository filmRepository;
		public CinemaController(ICinemaRepository cinemaRepository, IFilmRepository filmRepository)
		{
			this.cinemaRepository = cinemaRepository;
			this.filmRepository = filmRepository;
		}
		[AllowAnonymous]
		// GET: CinemaController
		public ActionResult Index()
		{
			var CinemasList = cinemaRepository.GetCinemaList();
			return View(CinemasList);
		}
		[AllowAnonymous]
        // GET: CinemaController/Details/5
        public ActionResult Details(int id)
		{
			var cinema = cinemaRepository.GetCinemaById(id);
			return View(cinema);
		}

		// GET: CinemaController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: CinemaController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Cinema cinema)
		{
			try
			{
				cinemaRepository.Ajouter(cinema);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: CinemaController/Edit/5
		public ActionResult Edit(int id)
		{
			var cinema = cinemaRepository.GetCinemaById(id);
			return View(cinema);
		}

		// POST: CinemaController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, Cinema cinema)
		{
			try
			{
				cinemaRepository.MAJ(cinema);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: CinemaController/Delete/5
		public ActionResult Delete(int id)
		{
			var cinema = cinemaRepository.GetCinemaById(id);
			return View(cinema);
		}

		// POST: CinemaController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, Cinema cinema)
		{
			try
			{
				cinemaRepository.Supprimer(cinema);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
