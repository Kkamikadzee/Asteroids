using System.Collections.Generic;

namespace Controller.GameObjectController
{
    public class GameObjectControllerStorage
    {
        private List<GameObjectController> _controllers;

        public IReadOnlyList<GameObjectController> Controllers => _controllers.AsReadOnly();

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
            foreach (var controller in _controllers)
            {
                controller.DestroyAll();
            }

            _controllers.Clear();
        }
    }
}