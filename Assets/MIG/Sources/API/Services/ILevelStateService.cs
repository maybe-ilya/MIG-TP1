namespace MIG.API
{
    public interface ILevelStateService : IService {
        void WinLevel();
        void LoseLevel();
    }
}
