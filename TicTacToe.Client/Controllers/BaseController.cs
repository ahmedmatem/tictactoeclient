namespace TicTacToe.Client.Controllers
{
    using System.Web.Mvc;
    using Data;

    public class BaseController : Controller
    {
        protected ITicTacToeData data;

        protected BaseController(ITicTacToeData data)
        {
            this.data = data;
        }
    }
}