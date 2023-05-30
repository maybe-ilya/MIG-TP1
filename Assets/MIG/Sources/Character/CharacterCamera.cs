using MIG.API;
using UnityEngine;
using UnityEngine.Animations;

namespace MIG.Character
{
    public sealed class CharacterCamera : MonoBehaviour, ICharacterCamera
    {
        [SerializeField]
        [CheckObject]
        private PositionConstraint _positionConstraint;

        private ICharacter _character;
        private IGameEntityKillNotifyService _killNotifyService;

        public void Init(IGameEntityKillNotifyService entityKillNotifyService)
        {
            _killNotifyService = entityKillNotifyService;
            _killNotifyService.OnGameEntityKill += OnGameEntityKill;
        }

        public void LookAt(ICharacter character)
        {
            _character = character;

            var source = new ConstraintSource
            {
                sourceTransform = _character.GameEntity.GameObject.transform,
                weight = 1
            };
            _positionConstraint.AddSource(source);
            _positionConstraint.constraintActive = true;
        }

        private void OnGameEntityKill(int entityId)
        {
            if (entityId != _character.GameEntity.Id)
            {
                return;
            }

            _killNotifyService.OnGameEntityKill -= OnGameEntityKill;

            _positionConstraint.constraintActive = false;
            _positionConstraint.RemoveSource(0);

            _character = null;
        }
    }
}
