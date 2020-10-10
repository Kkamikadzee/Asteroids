using System;
using Controller.GameObjectController.UpdateViewStrategy;
using KMK.Model.Base;
using KMK.Model.Updater;
using View.GameObjectView;

namespace Controller.GameObjectController
{
    public class GameObjectController
    {
        private IComponentsStorage _componentsStorageModel;
        private GameObjectView _gameObjectView;
        private IUpdateViewStrategy[] _updateViewStrategies;

        public IComponentsStorage GameObjectModel
        {
            get => _componentsStorageModel;
            set
            {
                if (_componentsStorageModel != null)
                {
                    _componentsStorageModel.Destruction -= _modelDestroyed;
                }

                _componentsStorageModel = value;
                foreach (var strategy in _updateViewStrategies)
                {
                    strategy.RefreshModelData(_componentsStorageModel);
                }
                
                _componentsStorageModel.Destruction += _modelDestroyed;
            }
        }

        public GameObjectView GameObjectView
        {
            get => _gameObjectView;
            set
            {
                if (_gameObjectView != null)
                {
                    _gameObjectView.Refresh -= _updateGameObjectView;
                }

                _gameObjectView = value;
                
                _gameObjectView.Refresh += _updateGameObjectView;
            }
        }

        public event Action<GameObjectController> Destruction; 
        
        public GameObjectController(IUpdateViewStrategy[] updateViewStrategies)
        {
            _updateViewStrategies = updateViewStrategies;
        }
        public GameObjectController(IComponentsStorage componentsStorageModel,
            GameObjectView gameObjectView, IUpdateViewStrategy[] updateViewStrategies)
        {
            _componentsStorageModel = componentsStorageModel;
            _componentsStorageModel.Destruction += _modelDestroyed;
            
            _gameObjectView = gameObjectView;
            _gameObjectView.Refresh += _updateGameObjectView;
            
            _updateViewStrategies = updateViewStrategies;
        }

        private void _updateGameObjectView(GameObjectView gameObjectView)
        {
            foreach (var strategy in _updateViewStrategies)
            {
                strategy.RefreshView(gameObjectView);
            }
        }

        private void _modelDestroyed(IComponentsStorage componentsStorageModel)
        {
            _componentsStorageModel = null;
            Destroy();
        }

        public void Destroy()
        {
            _componentsStorageModel?.Destroy();
            
            _gameObjectView?.Destroy();
            
            _componentsStorageModel = null;
            _gameObjectView = null;
            _updateViewStrategies = null;
            
            Destruction?.Invoke(this);
        }
    }
}