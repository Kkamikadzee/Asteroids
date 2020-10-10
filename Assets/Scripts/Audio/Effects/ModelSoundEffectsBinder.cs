using KMK.Model.Base;
using KMK.Model.Weapon;

namespace Audio.Effects
{
    public class ModelSoundEffectsBinder
    {
        private EffectsSources _effects;

        public ModelSoundEffectsBinder(EffectsSources effects)
        {
            _effects = effects;
        }

        public void Bind(IComponentsStorage componentsStorage)
        {
            componentsStorage.Destruction += storage => _effects.Explosion.Play();

            var cannon = componentsStorage.GetComponent<Weapon>();
            if (cannon != null)
            {
                cannon.Shot += weapon => _effects.CannonShot.PlayOneShot(_effects.CannonShot.clip);
            }

            var laser = componentsStorage.GetComponent<AutoAddLimitedAmmoWeapon>();
            if (laser != null)
            {
                laser.Shot += weapon => _effects.LaserShot.PlayOneShot(_effects.LaserShot.clip);
            }
        }
    }
}