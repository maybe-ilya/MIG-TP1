namespace MIG.API
{
    public interface IPlayerService : IService
    {
        IPlayer CreateNewPlayer();
        IPlayer GetPlayer();
    }
}
