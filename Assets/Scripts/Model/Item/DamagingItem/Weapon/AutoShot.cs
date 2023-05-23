using System.Collections;
using UnityEngine;

namespace SideScroller.Model.Item
{
    class AutoShot
    {
        private Weapon _weapon;
        private bool _isRedyToShoot = true;
        private Coroutine _weaponTimerCoroutine;

        public AutoShot(Weapon weapon)
        {
            _weapon = weapon;
        }

        public void Shoot()
        {
            if (!_isRedyToShoot) { return; }

            SetWeaponReadiness(false);
            _weapon.WeaponAttack();

            if (_weaponTimerCoroutine == null)
            {
                _weaponTimerCoroutine = _weapon.StartCoroutine(WeaponTimer());
            }

        }

        public void SetWeaponReadiness(bool state)
        {
            _isRedyToShoot = state;
        }


        #region IEnumerator

        private IEnumerator WeaponTimer()
        {
            yield return new WaitForSeconds(1f);
            SetWeaponReadiness(true);
            _weaponTimerCoroutine = null;
        }

        #endregion
    }
}
