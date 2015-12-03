namespace TicTacToe.Client.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using System.Collections.Generic;

    using Microsoft.AspNet.Identity;

    using TicTacToe.Data;
    using AutoMapper.QueryableExtensions;
    using Models;
    using System.Net;
    using Common;
    using TicTacToe.Models;
    using System.IO;
    using System.Web.Script.Serialization;

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

        [AllowAnonymous]
        public ActionResult Index()
        {
            IEnumerable<GameInfoDataModel> games = this.data.Games
                        .All()
                        .ProjectTo<GameInfoDataModel>()
                        .ToList();

            ViewBag.FirstPlayerName = this.User.Identity.GetUserName();

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