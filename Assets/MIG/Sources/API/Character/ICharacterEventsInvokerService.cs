namespace MIG.API
{
    public interface ICharacterEventsInvokerService : IService
    {
        void InvokeCharacterDeadEvent();
        void UpdateCharacterHealth(int currentHealth, int maxHealth);
        void UpdateCharacterAmmo(AmmoType ammoType, int currentAmount, int maxAmount);
    }
}
