namespace KMK.Model.Updater
{
    public interface IUpdaterObserver
    {
        void Update(float deltaTime);
    }
}