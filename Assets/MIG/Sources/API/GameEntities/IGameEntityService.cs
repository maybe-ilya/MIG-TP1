using UnityEngine;

namespace MIG.API
{
    public interface IGameEntityService : IService
    {
        GameEntity RegisterGameObject(GameObject gameObject);
        void DestroyEntity(GameEntity gameEntity);
    }
}
