namespace TicTacToe.Client.Hubs
{
    using System.IO;

    using Microsoft.AspNet.SignalR;

    using Common;

    public class GameHub : Hub
    {
        public void Join(string userAccessToken, string gameId, string secondPlayerName)
        {
            var response = HttpWebRequester.CreatePOST(userAccessToken, GlobalConstants.JoinServiceUri, null);

            var responseAsString =  new StreamReader(response.GetResponseStream()).ReadToEnd();
            if (gameId.CompareTo(responseAsString.Trim('\"')) == 0)
            {
                // if join is successfull
                Clients.All.join(gameId, secondPlayerName);
            }

            //if join is noy successfull
            //Clients.Client(Context.ConnectionId).join(GlobalConstants.JoinUnsuccessfull);
        }

        public void CreateNewGame(string userAccessToken)
        {
            var response = HttpWebRequester.CreatePOST(userAccessToken, GlobalConstants.CreateNewGameServiceUri, null);

            var gameId = new StreamReader(response.GetResponseStream()).ReadToEnd().Trim('\"');

            Clients.All.createNewGame(gameId);
        }
    }
}