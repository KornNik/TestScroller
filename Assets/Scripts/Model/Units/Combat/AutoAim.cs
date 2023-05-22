using System;
using System.Collections.Generic;
using UnityEngine;
using SideScroller.Data.Unit;
using SideScroller.Model.Item;

namespace SideScroller.Model.Unit.Combat
{
    class AutoAim : MonoBehaviour
    {
        [SerializeField] private CircleCollider2D _aimCollider;
        [SerializeField] private LayerMask _collisionLayer;
        [SerializeField] private Weapon _weapon;

        private List<Transform> _targetsInRadius;
        private const string ENEMY_LAYER_NAME = "Enemy";
        private Transform _target;
        private bool _isTarget;
        private Vector3 _aimDirection;

        private void Awake()
        {
            _collisionLayer = LayerMask.NameToLayer(ENEMY_LAYER_NAME);
            _targetsInRadius = new List<Transform>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == _collisionLayer)
            {
                ScanForTarget(collision);
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.layer == _collisionLayer)
            {
                TargetExitRadius(collision);
            }
        }
        private void Update()
        {
            if (IsTarget())
            {
                SetAim(_target);
            }
        }

        public bool IsTarget()
        {
            return _isTarget;
        }
        private void TargetExitRadius(Collider2D collision)
        {
            var exitTarget = collision.GetComponent<BaseNPC>();
            if (exitTarget)
            {
                _targetsInRadius.Remove(exitTarget.transform);
                if (exitTarget.transform == _target)
                {
                    if (_targetsInRadius.Count > 0)
                    {
                        SetTarget(_targetsInRadius[0]);
                    }
                    else
                    {
                        SetTarget(null);
                    }
                }
            }
        }
        private void ScanForTarget(Collider2D collision)
        {
            var newTarget = collision.GetComponent<BaseNPC>();
            if (newTarget)
            {
                _targetsInRadius.Add(newTarget.transform);

                if (_target != null)
                {
                    if (!_target.GetComponent<BaseNPC>().UnitBoolStates.IsDead)
                    {
                        return;
                    }
                }
                SetTarget(newTarget.transform);
            }
        }

        /// <summary>
        /// Sets the aim to the relative direction of the target
        /// </summary>
        private void SetAim(Transform target)
        {
            _aimDirection = (target.transform.position - _weapon.transform.position).normalized;
            _weapon.transform.rotation = Quaternion.LookRotation(_aimDirection);
        }
        private void SetFindTargetState(bool state)
        {
            _isTarget = state;
        }
        private void SetTarget(Transform newTarget)
        {
            _target = newTarget;

            if (_target != null)
            {
                SetFindTargetState(true);
            }
            else
            {
                SetFindTargetState(false);
            }
        }
    }
}
