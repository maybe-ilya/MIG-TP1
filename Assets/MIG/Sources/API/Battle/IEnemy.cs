namespace MIG.API
{
    public interface IEnemy : IGameEntityComponent {
        public void SetTarget(GameEntity gameEntity);
    }
}
