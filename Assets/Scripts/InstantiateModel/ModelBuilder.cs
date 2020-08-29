using KMK.Models.Base;
using KMK.Models.Builder;
using KMK.Models.Collision;
using Update;

namespace InstantiateModel
{
    public class ModelBuilder : GameObjectBuilder
    {
        private Updater _updater;
        
        private ICollisionChecker _collisionChecker;
        
        private ComponentsStorage _componentsStorage;

        public ModelBuilder(Updater updater, ICollisionChecker collisionChecker)
        {
            _updater = updater;
            _collisionChecker = collisionChecker;
        }

        private void _componentsStorageChecker()
        {
            if (_componentsStorage == null)
            {
                BuildComponentsStorage();
            }
        }
        
        public override void BuildComponentsStorage()
        {
            base.BuildComponentsStorage();
            
            _componentsStorage = new ComponentsStorage();
        }

        public override void BuildComponentsStorage(Transform transform)
        {
            base.BuildComponentsStorage(transform);
            
            _componentsStorage = new ComponentsStorage(transform);
        }

        public override void BuildSphereCollider()
        {
            base.BuildSphereCollider();
            
            
        }
    }
}