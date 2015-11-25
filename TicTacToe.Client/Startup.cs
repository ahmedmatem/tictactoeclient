using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TicTacToe.Client.Startup))]
namespace TicTacToe.Client
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
