using MIG.API;

namespace MIG.Battle
{
    public sealed class BattleLevelDependencies
    {
        public static ILevelStateService LevelStateService { get; private set; }

        public BattleLevelDependencies(ILevelStateService levelStateService)
        {
            LevelStateService = levelStateService;
        }
    }
}
