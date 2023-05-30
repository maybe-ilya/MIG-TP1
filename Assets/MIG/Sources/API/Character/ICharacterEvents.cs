using System;

namespace MIG.API
{
    public interface ICharacterEvents 
    {
        event Action<int, int> OnCharacterHealthChanged;
        event Action OnCharacterDead;
        event Action<AmmoType, int, int> OnCharacterAmmoChanged;
    }
}
