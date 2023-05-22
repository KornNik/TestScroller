using UnityEngine;
using SideScroller.Data.Unit.AI;
using SideScroller.Model.Unit.Movement;
using SideScroller.Model.Unit.Combat;
using SideScroller.Helpers.Managers;
using SideScroller.Helpers.Extensions;


namespace SideScroller.Model.Unit.AI
{
    class NPCAI
    {
        #region Fields

        protected BaseNPC _unit;
        protected BaseCombat _combat;
        protected IDamageable _target;
        protected BaseMovement _movement;
        protected AIParameters _AIParameters;

        protected bool _isDead;

        private Collider2D[] _targetsToChase; 

        #endregion


        #region ClassLifeCycle

        public NPCAI(BaseNPC unit, BaseMovement movement, BaseCombat combat,AIParameters AIParameters)
        {
            _unit = unit;
            _combat = combat;
            _movement = movement;
            _AIParameters = AIParameters;

            _targetsToChase = new Collider2D[32];
        }

        #endregion


        #region Methods

        public void DoAI()
        {
            if (IsTargetPresent())
            {
                AggressiveAction();
            }
        }

        private void AggressiveAction()
        {
            SearchTarget();
        }

        private void MoveToPoint(Vector3 point)
        {
            var heading = point - _unit.transform.position;
            var sqrMagnitude = heading.sqrMagnitude;
            if (!MathExtender.IsApproximatelyEqual(sqrMagnitude, _AIParameters.StopingDistance * _AIParameters.StopingDistance))
            {
                _unit.Movement.Move(point);
            }
        }
        protected virtual void ChaseTarget(Vector3 targetPosition)
        {
            if (!IsAtStopingDistance(targetPosition, _AIParameters.StopingDistance))
            {
                MoveToPoint(targetPosition);
            }
            else { AttackTarget(_target); }
        }
        protected virtual void AttackTarget(IDamageable damageable)
        {
            _combat.BegginAttack();
        }
        protected virtual void SearchTarget()
        {
            var targetsCount = Physics2D.OverlapCircleNonAlloc(_unit.transform.position, _AIParameters.DistanceView, _targetsToChase, LayersManager.PlayerLayer);
            for (int i = 0; i < targetsCount; i++)
            {
                var victim = _targetsToChase[i].GetComponent<BasePlayerCharacter>();
                if (victim != null)
                {
                    ChaseTarget(victim.transform.position);
                    _target = victim;
                }
            }
        }
        protected virtual bool IsTargetPresent()
        {
            var isFindTarget = Physics2D.OverlapCircle(_unit.transform.position, _AIParameters.DistanceView, LayersManager.PlayerLayer);
            return isFindTarget;
        }
        protected virtual bool IsAtStopingDistance(Vector3 destinationPoint, float stopingDistance)
        {
            if (Vector3.Distance(destinationPoint, _unit.transform.position) <= stopingDistance)
            {
                return true;
            }
            else { return false; }
        }

        #endregion

    }
}
