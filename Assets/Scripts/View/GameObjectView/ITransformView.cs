namespace View.GameObjectView
{
    public interface ITransformView
    {
        UnityEngine.Vector3 DisplayedPosition { get; }
        UnityEngine.Vector3 DisplayedEulerAngles { get; }
        UnityEngine.Vector3 DisplayedScale { get; }

        void MoveTo(UnityEngine.Vector3 position);
        void MoveTo(KMK.Model.Base.Vector3 position);
        
        void Translate(UnityEngine.Vector3 deltaPosition);
        void Translate(KMK.Model.Base.Vector3 deltaPosition);

        void RotateTo(UnityEngine.Vector3 eulerAngles);
        void RotateTo(KMK.Model.Base.Vector3 eulerAngles);

        void ScaleTo(UnityEngine.Vector3 scale);
        void ScaleTo(KMK.Model.Base.Vector3 scale);
    }
}