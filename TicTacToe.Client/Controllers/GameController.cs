namespace TicTacToe.Client.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using System.Collections.Generic;
    using System.IO;

    using Microsoft.AspNet.Identity;

    using Data;
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

        [HttpGet]
        public JsonResult Status(string gameId, string userAccessToken)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Authorization", "Bearer " + userAccessToken);

            string requestUri = GlobalConstants.ServerUri + GlobalConstants.StatusServiceUri + "?gameId=" + gameId;
            var response = HttpWebRequester.CreateGET(requestUri, headers);

            var responseAsString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            return Json(responseAsString, JsonRequestBehavior.AllowGet);
        }
    }
}