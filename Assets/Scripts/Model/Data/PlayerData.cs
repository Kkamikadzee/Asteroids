using KMK.Model.Collision;
using UnityEngine;

namespace Model.Data
{
    [CreateAssetMenu(fileName = "NewPlayerData", menuName = "Player Data", order = 101)]
    public class PlayerData : ScriptableObject
    {
        [SerializeField] private float _scale;

        [SerializeField] private float _colliderRadius;
        [SerializeField] private Vector3 _colliderCenter;
        [SerializeField] private ColliderTag _colliderTag;

        [SerializeField] private bool _moverIsRotateObject;

        [SerializeField] private float _maxVelocity;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _drag;

        [SerializeField] private float _maxAngularVelocity;
        [SerializeField] private float _angularAcceleration;
        [SerializeField] private float _angularDrag;

        [SerializeField] private float _fireRateFirstWeapon;

        [SerializeField] private float _fireRateSecondWeapon;
        [SerializeField] private int _maxAmountAmmoSecondWeapon;
        [SerializeField] private float _autoAddAmmoTimeSecondWeapon;

        public float Scale => _scale;

        public float ColliderRadius => _colliderRadius;
        public Vector3 ColliderCenter => _colliderCenter;
        public ColliderTag ColliderTag => _colliderTag;

        public bool MoverIsRotateObject => _moverIsRotateObject;

        public float MaxVelocity => _maxVelocity;
        public float Acceleration => _acceleration;
        public float Drag => _drag;

        public float MaxAngularVelocity => _maxAngularVelocity;
        public float AngularAcceleration => _angularAcceleration;
        public float AngularDrag => _angularDrag;

        public float FireRateFirstWeapon => _fireRateFirstWeapon;

        public float FireRateSecondWeapon => _fireRateSecondWeapon;
        public int MaxAmountAmmoSecondWeapon => _maxAmountAmmoSecondWeapon;
        public float AutoAddAmmoTimeSecondWeapon => _autoAddAmmoTimeSecondWeapon;
    }
}