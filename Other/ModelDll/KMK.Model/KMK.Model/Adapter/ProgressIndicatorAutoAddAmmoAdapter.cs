using KMK.Model.ViewInterface;
using KMK.Model.Weapon;

namespace KMK.Model.Adapter
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