namespace MIG.API
{
    public interface IBattleService : IService
    {
        void StartBattle(BattleModeType battleModeType);
        void FinishBattle();
    }
}
