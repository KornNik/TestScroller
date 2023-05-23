using UnityEngine;
using SideScroller.Helpers.Managers;

namespace SideScroller.Model.Item
{
    class Bullet : Projectile
    {
        [SerializeField] private LayerMask _collisionLayer;

        private LayerMask _playerLayer;

        protected override void Awake()
        {
            base.Awake();
            _playerLayer = LayersManager.PlayerLayer;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            var victim = collision.gameObject.GetComponent<IDamageable>();
            if(victim is IDamageable)
            {
                InflictDamage(victim);
            }

            ReturnToPool();
        }

        #region IDamager

        public override void InflictDamage(IDamageable damageable)
        {
            base.InflictDamage(damageable);
        }

        #endregion
    }
}