namespace SideScroller.Model.Item
{
    class CommonMeleeWeapon : Weapon
    {
        protected override void Awake()
        {
            base.Awake();
        }

        public override void WeaponAttack(IDamageable damageable)
        {
            base.WeaponAttack(damageable);
            InflictDamage(damageable);
        }

        #region IDamager

        public override void InflictDamage(IDamageable damageable)
        {
            base.InflictDamage(damageable);
        }

        #endregion
    }
}