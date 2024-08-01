using System;
using System.Collections;
using UnityEngine;

public class PlayerDamageDealer : MonoBehaviour
{
    [SerializeField] private float _shotDelay;

    public event Action ProjectileShot;

    private bool _isAbleToShoot = true;

    public void Shoot()
    {
        if (_isAbleToShoot)
        {
            _isAbleToShoot = false;

            ProjectileShot?.Invoke();

            StartCoroutine(CountShootCooldown());
        }
    }

    private IEnumerator CountShootCooldown()
    {
        yield return new WaitForSeconds(_shotDelay);

        _isAbleToShoot = true;
    }
}
