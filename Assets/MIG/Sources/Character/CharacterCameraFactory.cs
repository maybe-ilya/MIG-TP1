using MIG.API;

namespace MIG.Character
{
    public sealed class CharacterCameraFactory : ICharacterCameraFactory
    {
        private readonly IGameSettings _gameSettings;
        private readonly IGameEntityKillNotifyService _gameEntityKillNotifyService;

        public CharacterCameraFactory(
            IGameSettings gameSettings,
            IGameEntityKillNotifyService gameEntityKillNotifyService)
        {
            _gameSettings = gameSettings;
            _gameEntityKillNotifyService = gameEntityKillNotifyService;
        }

        public ICharacterCamera CreateObject()
        {
            var cameraPrefab = _gameSettings.CharacterCameraPrefab;
            var cameraGO = UnityEngine.Object.Instantiate(cameraPrefab);
            cameraGO.name = "[Character Camera]";
            var camera = cameraGO.GetComponent<CharacterCamera>();
            camera.Init(_gameEntityKillNotifyService);
            return camera;
        }
    }
}
