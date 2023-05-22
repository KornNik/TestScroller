using SideScroller.Helpers.Managers;

namespace SideScroller.Model.Unit.AnimationUnit
{
    class GunnerAnimation : UnitAnimation<Gunner>
    {
        protected override void Awake()
        {
            base.Awake();
            if (!_unitBehaviour)
            {
                _unitBehaviour = GetComponentInParent<Gunner>();
            }

            _eventHandler.SetEvent(GunnerAnimationClipManager.ATTACK, 0.5f, nameof(OnWeaponDamaging));
        }

        private void OnWeaponDamaging()
        {
            _unitBehaviour.Combat.AttackOnEventAnimation();
        }
    }
}
