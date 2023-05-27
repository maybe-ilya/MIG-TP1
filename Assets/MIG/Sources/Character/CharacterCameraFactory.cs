using MIG.API;

namespace MIG.Character
{
    public sealed class CharacterCameraFactory : ICharacterCameraFactory
    {
        private readonly IGameSettings _gameSettings;

        public CharacterCameraFactory(IGameSettings gameSettings)
        {
            _gameSettings = gameSettings;
        }

        public ICharacterCamera CreateObject()
        {
            var cameraPrefab = _gameSettings.CharacterCameraPrefab;
            var cameraGO = UnityEngine.Object.Instantiate(cameraPrefab);
            cameraGO.name = "[Character Camera]";
            var camera = cameraGO.GetComponent<ICharacterCamera>();
            return camera;
        }
    }
}
