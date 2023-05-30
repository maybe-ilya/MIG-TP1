using MIG.API;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MIG.UI
{
    public class CombatHUDWindow : MonoBehaviour, IWindow
    {
        [SerializeField]
        [CheckObject]
        private Image _healthImage;

        [SerializeField]
        [CheckObject]
        private Image _ammoImage;

        [SerializeField]
        [CheckObject]
        private TMP_Text _waveDataLabel;

        [SerializeField]
        [CheckObject]
        private TMP_Text _enemiesDataLabel;

        [SerializeField]
        private string _waveDataFormat;

        [SerializeField]
        private string _enemiesDataFormat;

        private ICharacterEvents _characterEvents;
        private IHordeModeEvents _hordeModeEvents;

        public WindowType WindowType => WindowType.CombatHUD;

        public void Init(ICharacterEvents characterEvents, IHordeModeEvents hordeModeEvents)
        {
            _characterEvents = characterEvents;
            _characterEvents.OnCharacterHealthChanged += OnHealthChanged;
            _characterEvents.OnCharacterAmmoChanged += OnAmmoChange;

            _hordeModeEvents = hordeModeEvents;
            _hordeModeEvents.OnWaveStarted += OnWaveStarted;
            _hordeModeEvents.OnWaveEnemiesCountChanged += OnEnemiesCountChanged;
        }

        public void Open() { }

        public void Close()
        {
            _characterEvents.OnCharacterAmmoChanged -= OnAmmoChange;
            _characterEvents.OnCharacterHealthChanged -= OnHealthChanged;
            _characterEvents = null;

            _hordeModeEvents.OnWaveStarted -= OnWaveStarted;
            _hordeModeEvents.OnWaveEnemiesCountChanged -= OnEnemiesCountChanged;
            _hordeModeEvents = null;

            Destroy(gameObject);
        }

        private void OnHealthChanged(int health, int maxHealth)
        {
            _healthImage.fillAmount = (float)health / maxHealth;
        }

        private void OnAmmoChange(AmmoType ammoType, int amount, int maxAmmount)
        {
            _ammoImage.fillAmount = (float)amount / maxAmmount;
        }

        private void OnWaveStarted(int currentWaveIndex, int maxWaves)
        {
            _waveDataLabel.text = string.Format(_waveDataFormat, currentWaveIndex, maxWaves);
        }

        private void OnEnemiesCountChanged(int enemiesLeft, int maxEnemies)
        {
            _enemiesDataLabel.text = string.Format(_enemiesDataFormat, enemiesLeft, maxEnemies);
        }
    }
}
