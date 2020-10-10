using System;
using KMK.Model.Base;
using KMK.Model.Updater;

namespace KMK.Model.Other.Pursuer
{
    public class PursuerPointer: Component, IUpdatable
    {
        private IPursuer _pursuer;
        private Transform _pursued;

        public Transform Pursued
        {
            get => _pursued;
            set => _pursued = value;
        }

        public event Action DisconnectFromObserver;

        public PursuerPointer(IComponentsStorage parent,
            IPursuer pursuer, Transform pursued) : base(parent)
        {
            _pursuer = pursuer;
            _pursued = pursued;
        }

        public void Update(float deltaTime)
        {
            if (_pursued != null)
            {
                _pursuer.SetPositionPursued(_pursued.Position);
            }
            else
            {
                _pursuer.SetPositionPursued(new Vector3(float.MaxValue, float.MaxValue, float.MaxValue));
            }
        }
        
        public override void Destroy()
        {
            base.Destroy();
            
            DisconnectFromObserver?.Invoke();
        }
    }
}