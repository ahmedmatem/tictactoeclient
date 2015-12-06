namespace TicTacToe.Client.Controllers
{
    using System.Web.Mvc;
    using System.Linq;
    using System.IO;

    using Microsoft.AspNet.Identity;

    using Data;
    using Common;

    [Authorize]
    public class BaseController : Controller
    {
        protected ITicTacToeData data;

        protected BaseController(ITicTacToeData data)
        {
            this.data = data;
        }

        protected string GetUserAccessToken()
        {
            var currentUserName = this.User.Identity.GetUserName();
            var userAccessToken = this.data.Tokens
                                    .All()
                                    .Where(t => t.UserName == currentUserName)
                                    .Select(t => t.AccessToken)
                                    .FirstOrDefault();

            return userAccessToken;
        }
    }
}