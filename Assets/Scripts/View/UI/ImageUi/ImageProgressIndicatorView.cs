using System;
using UnityEngine;
using UnityEngine.UI;

namespace View.UI.ImageUi
{
    public class ImageProgressIndicatorView: ProgressIndicatorView
    {
        private Image _image;
        private Gradient _gradient;
        
        public override event Action DisconnectFromObserver;
        public override event Action Refresh;

        public ImageProgressIndicatorView(Vector3 position, float displayedProgress,
            Image image, Gradient gradient) : base(position, displayedProgress)
        {
            _image = image;
            _gradient = gradient;
        }

        public override void Update(float deltaTime)
        {
            Refresh?.Invoke();
        }

        public override void Destroy()
        {
            DisconnectFromObserver?.Invoke();
            
            UnityEngine.Object.Destroy(_image);
        }

        public override void SetProgress(float progress)
        {
            _image.fillAmount = progress;
            _image.color = _gradient.Evaluate(progress);
        }
    }
}