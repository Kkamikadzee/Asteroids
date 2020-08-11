namespace KMK.Models.View
{
    public interface ILimitedResource
    {
        int MaxAmountResource { get; }
        int CurrentAmountResource { get; }
    }
}