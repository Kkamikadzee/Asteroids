using System;
using KMK.Model.Base;
using KMK.Model.Move;
using KMK.Model.Updater;

namespace KMK.Model.Other.Pursuer
{
    public class SimplePursuerMoveStrategy: Component, IUpdatable
    {
        private Pursuer _pursuer;
        private IDirectionMover _directionMover;
        private IAccelerationController _accelerationController;
        
        public event Action<SimplePursuerMoveStrategy> Destruction;
        public event Action DisconnectFromObserver;

        public SimplePursuerMoveStrategy(IComponentsStorage parent,
            Pursuer pursuer, IDirectionMover directionMover,
            IAccelerationController accelerationController) : base(parent)
        {
            _pursuer = pursuer;
            _directionMover = directionMover;
            _accelerationController = accelerationController;
        }

        public void Update(float deltaTime)
        {
            if (Vector3.Distance(_pursuer.PositionPursued, _pursuer.Transform.Position)
                <= _pursuer.PursuitRadius)
            {
                _accelerationController.Accelerate();

                _directionMover.DirectionMove
                    = (_pursuer.PositionPursued - _pursuer.Transform.Position).Normalized;
            }
        }
        
        public override void Destroy()
        {
            base.Destroy();
            
            DisconnectFromObserver?.Invoke();
            Destruction?.Invoke(this);
        }
    }
}