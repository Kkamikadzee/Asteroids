using KMK.Model.Other;
using KMK.Model.ViewInterface;

namespace KMK.Model.Adapter
{
    public class LimitedResourceHealthAdapter: ILimitedResource
    {
        private Health _health;
        
        public int CurrentAmountResource => _health.CurrentHealth;

        public LimitedResourceHealthAdapter(Health health)
        {
            _health = health;
        }
    }
}