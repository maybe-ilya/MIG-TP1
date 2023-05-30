namespace MIG.API
{
    public interface IHordeModeEventsInvokerService : IService
    {
        void InvokeWaveStartEvent(int waveIndex, int maxWaves);
        void InvokeWaveEnemiesCountChangedEvent(int enemiesLeft, int maxEnemies);
    }
}
