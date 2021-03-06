﻿using System.Collections.Generic;

namespace Controller.GameObjectController
{
    public class GameObjectControllerStorage
    {
        private List<GameObjectController> _controllers;

        public IReadOnlyList<GameObjectController> Controllers => _controllers.AsReadOnly();

        public GameObjectControllerStorage()
        {
            _controllers = new List<GameObjectController>();
        }
        
        public void AddController(GameObjectController controller)
        {
            _controllers.Add(controller);

            controller.Destruction += RemoveController;
        }
        
        public void RemoveController(GameObjectController controller)
        {
            controller.Destruction -= RemoveController;
            
            _controllers.Remove(controller);
        }

        public void Clear()
        {
            while (_controllers.Count != 0)
            {
                _controllers[0].Destroy();
            }

            _controllers.Clear();
        }
    }
}