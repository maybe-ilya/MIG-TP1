namespace MIG.API
{
    public interface IGameStateService : IService {
        void GoToMainMenu();
        void LaunchDemoBattle();
        void QuitGame();
    }
}
