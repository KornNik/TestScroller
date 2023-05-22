using UnityEngine;
using SideScroller.Data.Unit;

namespace SideScroller.Model.Unit.Movement
{
    class NPCMovement : BaseMovement
    {
        #region ClassLifeCycle

        public NPCMovement(BaseMovementParameters movementParameters, BaseUnit unitBehaviour)
            : base(movementParameters, unitBehaviour)
        {
            _movementParameters = movementParameters;
            _unitBehaviour = unitBehaviour;
        }

        #endregion


        #region Methods

        public override void Move(Vector2 movingDirection)
        {
            base.Move(movingDirection);

            var directionMovement = movingDirection - (Vector2)_unitBehaviour.transform.position;
            _unitBehaviour.transform.Translate(directionMovement * _movementParameters.MovingSpeed.GetValue() * Time.deltaTime);
        }
        protected override void FlipUnit(float movingInput)
        {
            base.FlipUnit(movingInput);
        }

        #endregion
    }
}