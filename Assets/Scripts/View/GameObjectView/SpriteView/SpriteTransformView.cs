using System;
using UnityEngine;
using Convert;

namespace View.GameObjectView.SpriteView
{
    public class SpriteTransformView: TransformView
    {
        private SpriteRenderer _spriteRenderer;

        public override Vector3 DisplayedPosition => _gameObject.transform.position;
        public override Vector3 DisplayedEulerAngles => _gameObject.transform.eulerAngles;
        public override Vector3 DisplayedScale => _gameObject.transform.localScale;
        
        public override event Action<GameObjectView> Refresh;

        public SpriteTransformView(GameObject gameObject, SpriteRenderer spriteRenderer) : base(gameObject)
        {
            _gameObject = gameObject;
            
            _spriteRenderer = spriteRenderer;
        }
        
        public override void MoveTo(Vector3 position) 
        {
            _gameObject.transform.position = position;
        }

        public override void MoveTo(KMK.Model.Base.Vector3 position)
        {
            _gameObject.transform.position = Converter.ToVector3(position);
        }

        public override void Translate(Vector3 deltaPosition)
        {
            _gameObject.transform.position += deltaPosition;
        }

        public override void Translate(KMK.Model.Base.Vector3 deltaPosition)
        {
            _gameObject.transform.position += Converter.ToVector3(deltaPosition);;
        }
        
        public override void RotateTo(Vector3 eulerAngles)
        {
            _gameObject.transform.eulerAngles = eulerAngles;
        }

        public override void RotateTo(KMK.Model.Base.Vector3 eulerAngles)
        {
            _gameObject.transform.eulerAngles = Converter.ToVector3(eulerAngles);
        }

        public override void ScaleTo(Vector3 scale)
        {
            _gameObject.transform.localScale = scale;
        }

        public override void ScaleTo(KMK.Model.Base.Vector3 scale)
        {
            _gameObject.transform.localScale = Converter.ToVector3(scale);
        }
        
        public override void Update(float deltaTime)
        {
            Refresh?.Invoke(this);
        }
    }
}