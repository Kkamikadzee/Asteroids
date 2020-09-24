using View.GameObjectView;

namespace KMK.Model.Builder
{
    public interface IAsteroidsGameObjectViewFactory
    {
        GameObjectView CreatePlayerView();
        GameObjectView CreateAsteroidView();
        GameObjectView CreateUfoView();
        GameObjectView CreateCannonBulletView();
        GameObjectView CreateLaserBulletView();
    }
}