namespace TicTacToe.Client.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using TicTacToe.Data;
    using AutoMapper.QueryableExtensions;
    using Models;
    using System.Collections;
    using System.Collections.Generic;

    public class HomeController : BaseController
    {
        public HomeController()
            : this(new TicTacToeData(new TicTacToeDbContext()))
        {

        }

        public HomeController(ITicTacToeData data)
            : base(data)
        {

        }

        public ActionResult Index()
        {
            IEnumerable<GameInfoDataModel> games = this.data.Games
                        .All()
                        .ProjectTo<GameInfoDataModel>()
                        .ToList();

            return View(games);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}