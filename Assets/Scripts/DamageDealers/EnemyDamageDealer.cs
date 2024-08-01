using System;
using System.Collections;
using UnityEngine;

public class EnemyDamageDealer : MonoBehaviour
{
    [SerializeField] private float _minShotDelay;
    [SerializeField] private float _maxShotDelay;

    private Coroutine _shooting;

    public event Action<EnemyDamageDealer> ProjectileShot;

    private void OnEnable()
    {
        _shooting = StartCoroutine(StartShooting());
    }

    private void OnDisable()
    {
        StopCoroutine(_shooting);
    }

    private IEnumerator StartShooting()
    {
        while (true) 
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(_minShotDelay, _maxShotDelay));
            
            ProjectileShot?.Invoke(this);
        }
    }
}
