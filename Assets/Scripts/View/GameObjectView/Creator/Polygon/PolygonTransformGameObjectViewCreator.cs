using UnityEngine;
using Update;
using View.GameObjectView.CreatorFactory;
using View.GameObjectView.PolygonView;

namespace View.GameObjectView.Creator.Polygon
{
    public class PolygonTransformGameObjectViewCreator: GameObjectViewCreator
    {
        private GameObject _prefab;
        private Transform _instantiateParent;

        public PolygonTransformGameObjectViewCreator(IUpdater updater, GameObject prefab,
            Transform instantiateParent) : base(updater)
        {
            _prefab = prefab;
            _instantiateParent = instantiateParent;
        }

        public override GameObjectView Create()
        {
            var view = Object.Instantiate(_prefab, _instantiateParent);
            
            var polygonTransformView = new PolygonTransformView(view);
            _updater.ViewObservable.AddUpdaterObserver(UpdateObserverCreator.GetObserver(
                polygonTransformView, _updater.ViewObservable));

            return polygonTransformView;
        }    }
}