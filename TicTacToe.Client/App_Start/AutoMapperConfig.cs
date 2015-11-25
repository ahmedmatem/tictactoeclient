namespace TicTacToe.Client
{
    using Models;
    using TicTacToe.Models;

    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            AutoMapper.Mapper.CreateMap<Game, GameInfoDataModel>()
                .ForMember(dest => dest.FirstPlayerName,
                opt => opt.MapFrom(src => src.FirstPlayer.UserName))
                .ForMember(dest => dest.SecondPlayerName,
                opt => opt.MapFrom(src => src.SecondPlayer.UserName));
        }
    }
}