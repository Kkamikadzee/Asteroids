namespace KMK.Models.Other
{
    public interface ILimitedResource
    {
        int MaxAmountResource { get; }
        int CurrentAmountResource { get; }
    }
}