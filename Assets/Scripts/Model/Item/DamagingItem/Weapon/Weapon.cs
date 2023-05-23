using UnityEngine;
using SideScroller.Data.Item;

namespace SideScroller.Model.Item
{
    abstract class Weapon : BaseItem, IDamager
    {
        [SerializeField] protected WeaponParameters _weaponParameters;

        public WeaponParameters WeaponParameters => _weaponParameters;

        protected override void Awake()
        {
            base.Awake();
        }

        public virtual void WeaponAttack(IDamageable damageable)
        {

        }
        public virtual void WeaponAttack()
        {

        }
        public void Equip()
        {
            ItemCollider.radius = _weaponParameters.ScanWeaponRadius.GetValue();
        }


        #region IDamager

        public virtual void InflictDamage(IDamageable damageable)
        {
            damageable.ReceiveDamage(_weaponParameters.Damage.BaseValue);
        }

        #endregion
    }
}
