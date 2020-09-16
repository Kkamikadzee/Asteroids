using KMK.Model.Collision;
using UnityEngine;

namespace Model.Data
{
    [CreateAssetMenu(fileName = "NewAsteroidData", menuName = "Asteroid Data", order = 102)]
    public class AsteroidData : ScriptableObject
    {
        [SerializeField] private float _scale;

        [SerializeField] private float _colliderRadius;
        [SerializeField] private Vector3 _colliderCenter;
        [SerializeField] private ColliderTag _colliderTag;

        [SerializeField] private bool _moverIsRotateObject;

        [SerializeField] private float _velocity;

        [SerializeField] private float _givenScore;

        public float Scale => _scale;

        public float ColliderRadius => _colliderRadius;
        public Vector3 ColliderCenter => _colliderCenter;
        public ColliderTag ColliderTag => _colliderTag;

        public bool MoverIsRotateObject => _moverIsRotateObject;

        public float Velocity => _velocity;

        public float GivenScore => _givenScore;
    }
}