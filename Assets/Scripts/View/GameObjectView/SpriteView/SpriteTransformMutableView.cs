using System;
using Convert;
using UnityEngine;

namespace View.GameObjectView.SpriteView
{
    public class SpriteTransformMutableView: TransformMutableView
    {
        private SpriteRenderer _spriteRenderer;

        private ViewState _viewState;

        private Sprite[] _sprites;

        public override Vector3 DisplayedPosition => _gameObject.transform.position;
        public override Vector3 DisplayedEulerAngles => _gameObject.transform.eulerAngles;
        public override Vector3 DisplayedScale => _gameObject.transform.localScale;

        public override ViewState DisplayedState
        {
            get => _viewState;
            set => _spriteRenderer.sprite = _sprites[(int)value];
        }

        public override event Action<GameObjectView> Refresh;

        public SpriteTransformMutableView(GameObject gameObject, SpriteRenderer spriteRenderer,
            ViewState viewState, Sprite[] sprites) : base(gameObject)
        {
            _spriteRenderer = spriteRenderer;

            _viewState = viewState;

            _sprites = sprites;
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