using SideScroller.Helpers.Managers;

namespace SideScroller.Model.Unit.AnimationUnit
{
    class MeleeEnemyAnimation : UnitAnimation<MeleeEnemy>
    {
        protected override void Awake()
        {
            base.Awake();
            if (!_unitBehaviour)
            {
                _unitBehaviour = GetComponent<MeleeEnemy>();
            }

            _eventHandler.SetEvent(BanditAnimationClipManager.ATTACK, 0.5f, nameof(OnWeaponDamaging));
        }

        private void OnWeaponDamaging()
        {
            _unitBehaviour.Combat.AttackOnEventAnimation();
        }
    }
}
