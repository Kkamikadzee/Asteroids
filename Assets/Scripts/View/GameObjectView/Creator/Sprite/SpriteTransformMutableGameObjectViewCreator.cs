using UnityEngine;
using Update;
using View.GameObjectView.CreatorFactory;
using View.GameObjectView.SpriteView;

namespace View.GameObjectView.Creator.Sprite
{
    public class SpriteTransformMutableGameObjectViewCreator: GameObjectViewCreator
    {
        private GameObject _prefab;
        private Transform _instantiateParent;

        private UnityEngine.Sprite[] _sprites;
        
        public SpriteTransformMutableGameObjectViewCreator(IUpdater updater, GameObject prefab,
            Transform instantiateParent, UnityEngine.Sprite[] sprites) : base(updater)
        {
            _prefab = prefab;
            _instantiateParent = instantiateParent;

            _sprites = sprites;
        }

        public override GameObjectView Create()
        {
            var view = Object.Instantiate(_prefab, _instantiateParent);
            
            var spriteTransformView = new SpriteTransformMutableView(view, view.GetComponent<SpriteRenderer>(),
                ViewState.Stay, _sprites);
            _updater.ViewObservable.AddUpdaterObserver(UpdateObserverCreator.GetObserver(
                spriteTransformView, _updater.ViewObservable));

            return spriteTransformView;
        }
    }
}