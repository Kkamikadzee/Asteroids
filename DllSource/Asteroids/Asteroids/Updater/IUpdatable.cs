using KMK.Models.Base;

namespace KMK.Models.Updater
{
    public interface IUpdatable
    {
        void Update(float deltaTime);
    }
}