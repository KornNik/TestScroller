using UnityEngine;
using SideScroller.Model.Unit.Combat;
using SideScroller.Model.Unit.AI;

namespace SideScroller.Model.Unit
{
    class MeleeEnemy : BaseNPC
    {
        #region UnityMethods

        protected override void Awake()
        {
            base.Awake();
            _combat = new MeleeCombat(_unitCombatParameters, this);
            _NPCBrains = new NPCAI(this, _movement, _combat, _AIParameters);
        }

        protected void Update()
        {
            _NPCBrains.DoAI();
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _AIParameters.DistanceView);
        }
        #endregion
    }
}