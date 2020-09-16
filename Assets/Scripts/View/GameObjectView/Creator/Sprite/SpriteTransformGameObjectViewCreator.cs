using UnityEngine;
using Update;
using View.GameObjectView.CreatorFactory;
using View.GameObjectView.SpriteView;

namespace View.GameObjectView.Creator.Sprite
{
    public class SpriteTransformGameObjectViewCreator: GameObjectViewCreator
    {
        private GameObject _prefab;
        private Transform _instantiateParent;

        public SpriteTransformGameObjectViewCreator(IUpdater updater, GameObject prefab,
            Transform instantiateParent) : base(updater)
        {
            _prefab = prefab;
            _instantiateParent = instantiateParent;
        }

        public override GameObjectView Create()
        {
            var view = Object.Instantiate(_prefab, _instantiateParent);
            
            var spriteTransformView = new SpriteTransformView(view, view.GetComponent<SpriteRenderer>());
            _updater.ViewObservable.AddUpdaterObserver(UpdateObserverCreator.GetObserver(
                spriteTransformView, _updater.ViewObservable));

            return spriteTransformView;
        }
    }
}