using System;
using KMK.Models.Base;
using KMK.Models.Updater;

namespace KMK.Models.Other.Pursuer
{
    public class PursuerPointer: Component, IUpdatable
    {
        private IPursuer _pursuer;
        private Transform _pursued;
        
        public event Action<PursuerPointer> Destruction;

        public PursuerPointer(IComponentsStorage parent,
            IPursuer pursuer, Transform pursued) : base(parent)
        {
            _pursuer = pursuer;
            _pursued = pursued;
        }

        public void Update(float deltaTime)
        {
            throw new System.NotImplementedException();
        }
        
        public override void Destroy()
        {
            base.Destroy();

            Destruction?.Invoke(this);
        }
    }
}