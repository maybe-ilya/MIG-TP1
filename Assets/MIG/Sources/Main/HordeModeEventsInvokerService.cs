using MIG.API;
using System;

namespace MIG.Main
{
    public sealed class HordeModeEventsInvokerService :
        IHordeModeEventsInvokerService,
        IHordeModeEvents
    {
        public event Action<int, int> OnWaveStarted;
        public event Action<int, int> OnWaveEnemiesCountChanged;

        public void InvokeWaveStartEvent(int waveIndex, int maxWaves) =>
            OnWaveStarted?.Invoke(waveIndex, maxWaves);

        public void InvokeWaveEnemiesCountChangedEvent(int enemiesLeft, int maxEnemies) =>
            OnWaveEnemiesCountChanged?.Invoke(enemiesLeft, maxEnemies);
    }
}
