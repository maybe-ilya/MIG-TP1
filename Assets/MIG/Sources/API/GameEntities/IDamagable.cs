namespace MIG.API
{
    public interface IDamagable
    {
        bool CanApplyDamage { get; }
        bool ApplyDamage(int damage);
    }
}
