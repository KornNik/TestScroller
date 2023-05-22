using UnityEngine;
using SideScroller.Data.Unit;

namespace SideScroller.Model.Unit.Movement
{
    class PlayerMovement : BaseMovement
    {
        #region ClassLifeCycle

        public PlayerMovement(BaseMovementParameters movementParameters, BaseUnit unitBehavior)
            : base(movementParameters, unitBehavior)
        {
            _movementParameters = movementParameters;
            _unitBehaviour = unitBehavior;
        }

        #endregion


        #region Methods

        public override void Move(Vector2 movingDirection)
        {
            base.Move(movingDirection);

            var normalizedMoving = movingDirection.normalized;
            if (!_unitBehaviour.UnitBoolStates.IsInvinsible)
            {
                var inputMovement = normalizedMoving * _movementParameters.MovingSpeed.GetValue() * Time.deltaTime;
                _unitBehaviour.transform.Translate(inputMovement, Space.World);
            }
        }
        protected override void FlipUnit(float movingInput)
        {
            base.FlipUnit(movingInput);
        }

        #endregion
    }
}