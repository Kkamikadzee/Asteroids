namespace KMK.Models.Weapon
{
    public interface ILimitedAmmo
    {
        int MaxAmountAmmo { get; }
        int CurrentAmountAmmo { get; }

        void AddAmmo(int amount);
    }
}