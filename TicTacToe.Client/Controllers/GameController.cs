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

    public class GameController : BaseController
    {
        public GameController()
            : this(new TicTacToeData(new TicTacToeDbContext()))
        { }

        public GameController(ITicTacToeData data)
            : base(data)
        { }

        public ActionResult List()
        {
            IEnumerable<GameInfoDataModel> games = this.data.Games
                            .All()
                            .ProjectTo<GameInfoDataModel>()
                            .ToList();

            ViewBag.FirstPlayerName = this.User.Identity.GetUserName();

            return View(games);
        }
        
        public ActionResult CreateNewGame()
        {
            var currentUserName = this.User.Identity.GetUserName();
            var userAccessToken = this.data.Tokens
                                    .All()
                                    .Where(t => t.UserName == currentUserName)
                                    .Select(t => t.AccessToken)
                                    .FirstOrDefault();

            ViewBag.GameId = this.GameResponse(userAccessToken, GlobalConstants.CreateNewGameServiceUri, null);

            return RedirectToAction("List");
        }
        
        //public ActionResult Join()
        //{
        //    var currentUserName = this.User.Identity.GetUserName();
        //    var userAccessToken = this.data.Tokens
        //                            .All()
        //                            .Where(t => t.UserName == currentUserName)
        //                            .Select(t => t.AccessToken)
        //                            .FirstOrDefault();
        //    //ViewBag.GameId = this.GameResponse(userAccessToken, "/api/games/join");

        //    return RedirectToAction("Index");
        //}
    }
}