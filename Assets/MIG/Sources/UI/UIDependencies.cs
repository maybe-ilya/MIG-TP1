using MIG.API;

namespace MIG.UI
{
    public sealed class UIDependencies
    {
        public static IGameStateService GameStateService { get; private set; }

        public UIDependencies(IGameStateService gameStateService)
        {
            GameStateService = gameStateService;
        }
    }
}
