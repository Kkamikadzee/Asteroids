using KMK.Model.Base;

namespace KMK.Model.Weapon
{
    public class AutoAddLimitedAmmoWeapon: Weapon, ILimitedAmmo, IAutoAddAmmo
    {
        private int _maxAmountAmmo;
        private int _currentAmountAmmo;
        private float _autoAddAmmoTime;
        private float _currentAutoAddAmmoTime;

        public int MaxAmountAmmo => _maxAmountAmmo;
        public int CurrentAmountAmmo => _currentAmountAmmo;
        public float ProgressAddingAmmo => _progressAddingAmmo();


        public AutoAddLimitedAmmoWeapon(IComponentsStorage parent, 
            float firerate, int maxAmountAmmo, float autoAddAmmoTime)
            : base(parent, firerate)
        {
            _currentAmountAmmo = maxAmountAmmo;
            _maxAmountAmmo = maxAmountAmmo;
            _autoAddAmmoTime = autoAddAmmoTime;
        }

        private float _progressAddingAmmo()
        {
            var progress = _currentAutoAddAmmoTime / _autoAddAmmoTime;
            return progress <= 1f ? progress : 1f;
        }

        protected override bool _canShoot()
        {
            return (_currentAmountAmmo > 0) 
                    && (base._canShoot());
        }

        public void AddAmmo(int amount)
        {
            if (_currentAmountAmmo < _maxAmountAmmo)
            {
                _currentAmountAmmo += amount;
            }
        }

        public override void Shoot()
        {
            if (_canShoot())
            {
                base.Shoot();
                _currentAmountAmmo--;
            }
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            if (_currentAmountAmmo < _maxAmountAmmo)
            {
                _currentAutoAddAmmoTime += deltaTime;
                if (_currentAutoAddAmmoTime >= _autoAddAmmoTime)
                {
                    _currentAmountAmmo++;
                    _currentAutoAddAmmoTime = 0;                
                }
            }
        }
    }
}