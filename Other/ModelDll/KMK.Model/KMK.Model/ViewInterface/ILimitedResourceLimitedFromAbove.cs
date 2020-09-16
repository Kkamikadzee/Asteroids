namespace KMK.Model.ViewInterface
{
    public interface ILimitedResourceLimitedFromAbove: ILimitedResource
    {
        int MaxAmountResource { get; }
    }
}