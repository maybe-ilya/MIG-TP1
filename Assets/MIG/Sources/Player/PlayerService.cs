using MIG.API;

namespace MIG.Player
{
    public sealed class PlayerService : IPlayerService
    {
        private readonly IPlayerFactory _playerFactory;
        private IPlayer _spawnedPlayer;

        public PlayerService(IPlayerFactory playerFactory)
        {
            _playerFactory = playerFactory;
        }

        public IPlayer CreateNewPlayer()
        {
            _spawnedPlayer = _playerFactory.CreateObject();
            return _spawnedPlayer;
        }

        public IPlayer GetPlayer()
        {
            return _spawnedPlayer;
        }
    }
}
