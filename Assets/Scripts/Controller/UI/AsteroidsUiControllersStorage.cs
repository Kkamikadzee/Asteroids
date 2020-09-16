namespace Controller.UI
{
    public class AsteroidsUiControllersStorage: IAsteroidsUiControllersStoragePlayerInfo
    {
        private IUiViewController _score;
        private IUiViewController _reloadLaser;
        private IUiViewController _laserAmmo;
        private IUiViewController _health;

        public IUiViewController Score
        {
            get => _score;
            set => _score = value;
        }

        public IUiViewController ReloadLaser
        {
            get => _reloadLaser;
            set => _reloadLaser = value;
        }

        public IUiViewController LaserAmmo
        {
            get => _laserAmmo;
            set => _laserAmmo = value;
        }

        public IUiViewController Health
        {
            get => _health;
            set => _health = value;
        }
        
        public AsteroidsUiControllersStorage() { }

        public AsteroidsUiControllersStorage(IUiViewController score, IUiViewController reloadLaser,
            IUiViewController laserAmmo, IUiViewController health)
        {
            _score = score;
            _reloadLaser = reloadLaser;
            _laserAmmo = laserAmmo;
            _health = health;
        }
    }
}