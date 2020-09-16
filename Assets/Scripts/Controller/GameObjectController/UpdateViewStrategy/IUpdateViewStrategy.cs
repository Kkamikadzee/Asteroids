using KMK.Model.Base;
using View.GameObjectView;

namespace Controller.GameObjectController.UpdateViewStrategy
{
    public interface IUpdateViewStrategy
    {
        void RefreshView(GameObjectView gameObjectView);
        void RefreshModelData(IComponentsStorage componentsStorage);
    }
}