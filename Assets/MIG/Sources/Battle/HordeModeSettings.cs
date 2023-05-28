using UnityEngine;

namespace MIG.Battle
{
    [CreateAssetMenu(menuName = "MIG/Horde Mode Settings")]
    public sealed class HordeModeSettings : ScriptableObject
    {
        [SerializeField]
        private EnemyWaveData[] _hordeWaves;

        public EnemyWaveData[] HordeWaves => _hordeWaves;
    }
}
