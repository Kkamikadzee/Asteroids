using KMK.Models.View;
using KMK.Models.Weapon;

namespace KMK.Models.Adapter
{
    public class ProgressIndicatorAutoAddAmmoAdapter: IProgressIndicator
    {
        private readonly IAutoAddAmmo _autoAddAmmo;

        public float Progress => _autoAddAmmo.ProgressAddingAmmo;

        public ProgressIndicatorAutoAddAmmoAdapter(IAutoAddAmmo autoAddAmmo)
        {
            _autoAddAmmo = autoAddAmmo;
        }
    }
}