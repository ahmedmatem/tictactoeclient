namespace TicTacToe.Client.Controllers
{
    using System.Web.Mvc;
    using System.Net;
    using System.IO;

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

        protected string GameResponse(string userAccessToken, string servicePath, string postData)
        {
            var response = HttpWebRequester.Create(userAccessToken, servicePath, postData);

            return new StreamReader(response.GetResponseStream()).ReadToEnd();
        }
    }
}