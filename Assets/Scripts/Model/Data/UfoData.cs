using KMK.Model.Collision;
using UnityEngine;

namespace Model.Data
{    
    [CreateAssetMenu(fileName = "NewUfoData", menuName = "Ufo Data", order = 103)] 
    public class UfoData : ScriptableObject
    {
        [SerializeField] private float _scale;

        [SerializeField] private float _colliderRadius;
        [SerializeField] private Vector3 _colliderCenter;
        [SerializeField] private ColliderTag _colliderTag;

        [SerializeField] private bool _moverIsRotateObject;

        [SerializeField] private float _maxVelocity;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _drag;

        [SerializeField] private float _givenScore;
        
        [SerializeField] private float _pursuitRadius;

        public float Scale => _scale;

        public float ColliderRadius => _colliderRadius;
        public Vector3 ColliderCenter => _colliderCenter;
        public ColliderTag ColliderTag => _colliderTag;

        public bool MoverIsRotateObject => _moverIsRotateObject;

        public float MaxVelocity => _maxVelocity;
        public float Acceleration => _acceleration;
        public float Drag => _drag;

        public float GivenScore => _givenScore;

        public float PursuitRadius => _pursuitRadius;
    }
}