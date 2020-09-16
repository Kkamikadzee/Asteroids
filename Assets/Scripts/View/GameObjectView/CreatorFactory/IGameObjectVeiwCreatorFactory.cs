using View.GameObjectView.Creator;

namespace View.GameObjectView.CreatorFactory
{
    public interface IGameObjectViewCreatorFactory
    {
        GameObjectViewCreator PlayerCreator { get; }
        GameObjectViewCreator AsteroidCreator { get; }
        GameObjectViewCreator UfoCreator { get; }
        GameObjectViewCreator CannonBulletCreator { get; }
        GameObjectViewCreator LaserBulletCreator { get; }
    }
}