using KMK.Model.Base;
using KMK.Model.Move;
using KMK.Model.Weapon;

namespace Input
{
    public class PlayerInputController
    {
        private SystemInput _systemInput;

        private IAccelerationController _move;
        private IAccelerationController _rotate;

        private IShootable _firstWeapon;
        private IShootable _secondWeapon;

        public PlayerInputController(SystemInput systemInput)
        {
            _systemInput = systemInput;
        }

        public void ClearPlayerRefs()
        {
            _systemInput.Vertical -= _move.Accelerate;
            _systemInput.HorizontalLeft -= _rotate.Accelerate;
            _systemInput.HorizontalRight -= _rotate.Decelerate;
            _systemInput.Cannon -= _firstWeapon.Shoot;
            _systemInput.Laser -= _secondWeapon.Shoot;

            _move = _rotate = null;
            _firstWeapon = _secondWeapon = null;
        }
        
        public void ClearPlayerRefs(IComponentsStorage componentsStorage) //TODO: Для подписки на событие, естественно это нужно исправлять, но времени нет...
        {
            ClearPlayerRefs();
        }
        
        public void SetPlayerRef(IAccelerationController move, IAccelerationController rotate,
            IShootable firstWeapon, IShootable secondWeapon)
        {
            _move = move;
            _rotate = rotate;
            _firstWeapon = firstWeapon;
            _secondWeapon = secondWeapon;
            
            _systemInput.Vertical += _move.Accelerate;
            _systemInput.HorizontalLeft += _rotate.Accelerate;
            _systemInput.HorizontalRight += _rotate.Decelerate;
            _systemInput.Cannon += _firstWeapon.Shoot;
            _systemInput.Laser += _secondWeapon.Shoot;
        }
    }
}