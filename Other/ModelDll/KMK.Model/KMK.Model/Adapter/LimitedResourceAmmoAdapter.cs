using KMK.Model.Other;
using KMK.Model.ViewInterface;
using KMK.Model.Weapon;

namespace KMK.Model.Adapter
{
    public class LimitedResourceAmmoAdapter: ILimitedResourceLimitedFromAbove
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