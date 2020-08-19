using KMK.Models.Other;
using KMK.Models.Weapon;

namespace KMK.Models.Adapter
{
    public class LimitedResourceAmmoAdapter: ILimitedResource
    {
        private readonly ILimitedAmmo _limitedAmmo;

        public int MaxAmountResource => _limitedAmmo.MaxAmountAmmo;
        public int CurrentAmountResource => _limitedAmmo.CurrentAmountAmmo;

        public LimitedResourceAmmoAdapter(ILimitedAmmo limitedAmmo)
        {
            _limitedAmmo = limitedAmmo;
        }
    }
}