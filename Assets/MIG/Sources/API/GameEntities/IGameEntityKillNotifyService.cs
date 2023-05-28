using System;

namespace MIG.API
{
    public interface IGameEntityKillNotifyService : IService
    {
        event Action<int> OnGameEntityKill;
    }
}
