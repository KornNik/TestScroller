using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SideScroller.Model.Item
{
    class AutoAim : MonoBehaviour
    {
        #region Fields

        [SerializeField] private LayerMask _collisionLayer;
        [SerializeField] private Weapon _weapon;
        [SerializeField] private LayerMask _obstacleLayer;

        private const int OVERLAP_MAXIMUM = 15;

        private Transform _target;
        private bool _isTarget;
        private Vector3 _aimDirection;
        private Collider2D[] _overlapResults;
        private WaitForSeconds _scanFrequency;
        protected List<Transform> _potentialTargets;
        protected Vector3 _boxcastDirection;
        protected RaycastHit2D _hit;
        public Vector2 LineOfFireBoxcastSize = new Vector2(0.1f, 0.1f);
        private bool _isScanActive;
        private AutoShot _autoShot;

        private Coroutine _overlapCoroutine;

        #endregion

        private void Awake()
        {
            Initialization();
        }
        private void OnEnable()
        {
            SetScanState(true);
        }
        private void OnDisable()
        {
            SetScanState(false);
        }

        private void Initialization()
        {
            _scanFrequency = new WaitForSeconds(0.5f);
            _overlapResults = new Collider2D[OVERLAP_MAXIMUM];
            _potentialTargets = new List<Transform>();
            _autoShot = new AutoShot(_weapon);
        }
        private bool MakeOverlap()
        {
            SetTarget(null);

            int numberOfResults = Physics2D.OverlapCircleNonAlloc(transform.position, _weapon.WeaponParameters.ScanWeaponRadius.GetValue(), _overlapResults, _collisionLayer);
            // if there are no targets around, we exit
            if (numberOfResults == 0)
            {
                return false;
            }
            _potentialTargets.Clear();

            // we go through each collider found

            int min = Mathf.Min(OVERLAP_MAXIMUM, numberOfResults);
            for (int i = 0; i < min; i++)
            {
                if (_overlapResults[i] == null)
                {
                    continue;
                }

                _potentialTargets.Add(_overlapResults[i].gameObject.transform);
            }


            // we sort our targets by distance
            _potentialTargets.Sort(delegate (Transform a, Transform b)
            {
                return ((transform.position - a.position).sqrMagnitude)
                .CompareTo((transform.position - b.position).sqrMagnitude);
            });

            // we return the first unobscured target
            foreach (Transform t in _potentialTargets)
            {
                _boxcastDirection = (Vector2)(t.gameObject.GetComponent<Collider2D>().bounds.center - transform.position);

                _hit = Physics2D.BoxCast(transform.position, LineOfFireBoxcastSize, 0f, _boxcastDirection.normalized, _boxcastDirection.magnitude, _obstacleLayer);

                if (!_hit)
                {
                    SetTarget(t);
                    return true;
                }
            }

            return false;
        }

        private void Update()
        {
            if (IsTarget())
            {
                SetAim(_target);
                _autoShot.Shoot();
            }
        }

        public bool IsTarget()
        {
            return _isTarget;
        }
        public bool IsScaning()
        {
            return _isScanActive;
        }
        private void SetScanState(bool state)
        {
            _isScanActive = state;

            if (state)
            {
                if (_overlapCoroutine == null)
                {
                    _overlapCoroutine = StartCoroutine(StartScanCoroutine());
                }
            }
            else
            {
                _overlapCoroutine = null;
            }
        }

        private void SetAim(Transform target)
        {
            _aimDirection = target.transform.position - _weapon.transform.position;
            Vector3 rotatedVectorToTarget = Quaternion.Euler(0, 0, 90) * _aimDirection;
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, rotatedVectorToTarget);
            _weapon.transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 5 * Time.deltaTime);
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

        #region IEnumerator

        private IEnumerator StartScanCoroutine()
        {
            while (IsScaning())
            {
                yield return _scanFrequency;
                MakeOverlap();
            }
        }

        #endregion
    }
}
