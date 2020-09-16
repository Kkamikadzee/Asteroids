using UnityEngine;
using UnityEngine.UI;

namespace View.UI
{
    public class UnityAsteroidsUi: MonoBehaviour
    {
        [SerializeField] private Text _scoreText;
        [SerializeField] private Image _reloadLaserImage;
        [SerializeField] private GameObject _laserAmmoStorage;
        [SerializeField] private GameObject _healthStorage;

        [SerializeField] private Gradient _gradientForReloadLaserView;
        [SerializeField] private GameObject _laserAmmoPrefab;
        [SerializeField] private GameObject _healthPrefab;

        public Text ScoreText => _scoreText;
        public Image ReloadLaserImage => _reloadLaserImage;
        public GameObject LaserAmmoStorage => _laserAmmoStorage;
        public GameObject HealthStorage => _healthStorage;

        public Gradient GradientForReloadLaserView => _gradientForReloadLaserView;
        public GameObject LaserAmmoPrefab => _laserAmmoPrefab;
        public GameObject HealthPrefab => _healthPrefab;
    }
}