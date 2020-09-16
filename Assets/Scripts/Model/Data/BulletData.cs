using KMK.Model.Collision;
using UnityEngine;

namespace Model.Data
{
    [CreateAssetMenu(fileName = "NewBulletData", menuName = "Bullet Data", order = 104)]
    public class BulletData : ScriptableObject
    {
        [SerializeField] private float _scale;

        [SerializeField] private float _colliderRadius;
        [SerializeField] private Vector3 _colliderCenter;
        [SerializeField] private ColliderTag _colliderTag;

        [SerializeField] private bool _moverIsRotateObject;

        [SerializeField] private float _velocity;

        [SerializeField] private float _lifetime;
        
        [SerializeField] private bool _destroyIfHit;

        public float Scale => _scale;

        public float ColliderRadius => _colliderRadius;
        public Vector3 ColliderCenter => _colliderCenter;
        public ColliderTag ColliderTag => _colliderTag;

        public bool MoverIsRotateObject => _moverIsRotateObject;

        public float Velocity => _velocity;

        public float Lifetime => _lifetime;
        
        public bool DestroyIfHit => _destroyIfHit;
    }
}