using System.Reflection;
using KMK.Models.Base;

namespace KMK.Models.Builder
{
    public abstract class GameObjectDirector
    {
        protected GameObjectBuilder _builder;

        protected GameObjectDirector(GameObjectBuilder builder)
        {
            _builder = builder;
        }

        public abstract void Constructor();
        public abstract void Constructor(Transform transform);
    }
}