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

        public void LookAt(ICharacter character)
        {
            var source = new ConstraintSource
            {
                sourceTransform = character.GameEntity.GameObject.transform,
                weight = 1
            };
            _positionConstraint.AddSource(source);
            _positionConstraint.constraintActive = true;
        }
    }
}
