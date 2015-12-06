namespace TicTacToe.Client.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using System.Collections.Generic;

    using Microsoft.AspNet.Identity;

    using TicTacToe.Data;
    using AutoMapper.QueryableExtensions;
    using Models;
    using Common;
    using Hubs;

    public class GameController : BaseController
    {
        public GameController()
            : this(new TicTacToeData(new TicTacToeDbContext()))
        { }

        public GameController(ITicTacToeData data)
            : base(data)
        { }

        [HttpGet]
        public ActionResult List()
        {
            IEnumerable<GameInfoDataModel> games = this.data.Games
                            .All()
                            .ProjectTo<GameInfoDataModel>()
                            .ToList();

            ViewBag.CurrentUserName = this.User.Identity.GetUserName();
            ViewBag.UserAccessToken = this.GetUserAccessToken();

            return View(games);
        }
    }
}