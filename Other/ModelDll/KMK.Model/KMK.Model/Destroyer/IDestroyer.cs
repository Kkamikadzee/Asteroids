namespace KMK.Model.Destroyer
{
    public interface IDestroyer
    {
        void AddDestroyableObject(IDestroyable destroyable);
        void RemoveDestroyableObject(IDestroyable destroyable);
    }
}