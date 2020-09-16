using UnityEngine;

namespace View.GameObjectView
{
    public abstract class TransformView: GameObjectView, ITransformView
    {
        public abstract UnityEngine.Vector3 DisplayedPosition { get; }
        public abstract UnityEngine.Vector3 DisplayedEulerAngles { get; }
        public abstract UnityEngine.Vector3 DisplayedScale { get; }

        protected TransformView(GameObject gameObject) : base(gameObject) { }
        
        public abstract void MoveTo(UnityEngine.Vector3 position);
        public abstract void MoveTo(KMK.Model.Base.Vector3 position);

        public abstract void Translate(UnityEngine.Vector3 deltaPosition);
        public abstract void Translate(KMK.Model.Base.Vector3 deltaPosition);
        
        public abstract void RotateTo(Vector3 eulerAngles);

        public abstract void RotateTo(KMK.Model.Base.Vector3 eulerAngles);

        public abstract void ScaleTo(Vector3 scale);

        public abstract void ScaleTo(KMK.Model.Base.Vector3 scale);
    }
}