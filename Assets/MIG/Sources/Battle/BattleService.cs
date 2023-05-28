using MIG.API;

namespace MIG.Battle
{
    public sealed class BattleService : IBattleService
    {
        private readonly IBattleModeFactory _battleModeFactory;
        private readonly ILogService _logService;
        private readonly LogChannel _logChannel;
        private IBattleMode _activeBattleMode;

        public BattleService(
            IBattleModeFactory battleModeFactory,
            ILogService logService)
        {
            _battleModeFactory = battleModeFactory;
            _logService = logService;
            _logChannel = "[BATTLE]";
        }

        public void StartBattle(BattleModeType battleModeType)
        {
            _logService.Info(_logChannel, $"Starting {battleModeType} battle");
            _activeBattleMode = _battleModeFactory.CreateObject(battleModeType);
            _activeBattleMode.Start();
        }

        public void FinishBattle()
        {
            throw new System.NotImplementedException();
        }
    }
}
