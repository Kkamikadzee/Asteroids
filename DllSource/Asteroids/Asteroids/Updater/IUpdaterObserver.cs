namespace KMK.Models.Updater
{
    public interface IUpdaterObserver
    {
        void Update(float deltaTime);
    }
}