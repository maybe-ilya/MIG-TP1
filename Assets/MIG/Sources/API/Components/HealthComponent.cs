using System;
using UnityEngine;

namespace MIG.API
{
    public sealed class HealthComponent : MonoBehaviour
    {
        [SerializeField]
        private int _maxHealth;

        private int _health;

        public int Health => _health;

        public int MaxHealth => _maxHealth;

        public bool IsAlive => _health > 0;

        public bool IsDead => !IsAlive;

        public void Init()
        {
            _health = _maxHealth;
        }

        public void GainHealth(int amount)
        {
            _health = Math.Max(_health + amount, _maxHealth);
        }

        public void LoseHealth(int amount)
        {
            _health = Math.Max(_health - amount, 0);
        }
    }
}
