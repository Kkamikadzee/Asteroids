using System;
using KMK.Models.Base;
using KMK.Models.Updater;

namespace KMK.Models.Weapon
{
    public class Weapon: Component, IUpdatable, IShootable, IReloadProgressWeapon
    {
        private float _firerate;
        private float _delayBetweenShots;
        private float _currentTimeBetweenShots;
        
        public event Action<Weapon> Destruction;
        public event Action<Weapon> Shot;

        public float ReloadProgress => _reloadProgress();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="firerate">RPM</param>
        public Weapon(IComponentsStorage parent, float firerate) : base(parent)
        {
            _firerate = firerate;
            _delayBetweenShots = firerate / 60f;
        }

        private float _reloadProgress()
        {
            var progress = _currentTimeBetweenShots / _delayBetweenShots;
            return progress <= 1f ? progress : 1f;
        }
        
        protected virtual bool _canShoot()
        {
            return _currentTimeBetweenShots >= _delayBetweenShots;
        }
        
        public virtual void Update(float deltaTime)
        {
            if (_currentTimeBetweenShots < _delayBetweenShots)
            {
                _currentTimeBetweenShots += deltaTime;
            }
        }

        public virtual void Shoot()
        {
            if (_canShoot())
            {
                _currentTimeBetweenShots = 0f;
                Shot?.Invoke(this);
            }
        }

        public override void Destroy()
        {
            base.Destroy();

            Destruction?.Invoke(this);
        }
    }
}