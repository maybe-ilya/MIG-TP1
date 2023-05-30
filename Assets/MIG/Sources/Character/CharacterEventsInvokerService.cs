using MIG.API;
using System;

namespace MIG.Character
{
    public sealed class CharacterEventsInvokerService :
        ICharacterEventsInvokerService,
        ICharacterEvents
    {
        public event Action<int, int> OnCharacterHealthChanged;
        public event Action OnCharacterDead;
        public event Action<AmmoType, int, int> OnCharacterAmmoChanged;

        public void InvokeCharacterDeadEvent() =>
            OnCharacterDead?.Invoke();

        public void UpdateCharacterHealth(int currentHealth, int maxHealth) =>
            OnCharacterHealthChanged?.Invoke(currentHealth, maxHealth);

        public void UpdateCharacterAmmo(AmmoType ammoType, int currentAmount, int maxAmount) =>
            OnCharacterAmmoChanged?.Invoke(ammoType, currentAmount, maxAmount);
    }
}
