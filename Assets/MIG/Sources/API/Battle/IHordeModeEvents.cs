using System;

namespace MIG.API
{
    public interface IHordeModeEvents
    {
        event Action<int, int> OnWaveStarted;
        event Action<int, int> OnWaveEnemiesCountChanged;
    }
}
