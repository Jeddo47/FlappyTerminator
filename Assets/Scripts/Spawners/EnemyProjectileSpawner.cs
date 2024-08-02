using System;
using UnityEngine;

public class EnemyProjectileSpawner : GenericSpawner<EnemyProjectileReleaseTracker>
{
    [SerializeField] private EnemySpawner _enemySpawner;

    private EnemyDamageDealer _currentEnemy;

    public event Action ProjectileSpawned;

    private void OnEnable()
    {
        _enemySpawner.EnemySpawned += SubscribeToShootEvent;
        _enemySpawner.EnemyRemoved += UnsubscribeFromShootEvent;
    }

    private void OnDisable()
    {
        _enemySpawner.EnemySpawned -= SubscribeToShootEvent;
        _enemySpawner.EnemyRemoved -= UnsubscribeFromShootEvent;
    }

    protected override void OnGet(EnemyProjectileReleaseTracker projectile)
    {
        projectile.transform.position = _currentEnemy.transform.position;
        projectile.gameObject.SetActive(true);
        projectile.ReleaseStateReached += ReleaseObject;

        ProjectileSpawned?.Invoke();
    }

    protected override void ReleaseObject(EnemyProjectileReleaseTracker projectile)
    {
        base.ReleaseObject(projectile);

        projectile.ReleaseStateReached -= ReleaseObject;
    }

    private void SpawnProjectile(EnemyDamageDealer enemy) 
    {
        _currentEnemy = enemy;

        GetObject();
    }

    private void SubscribeToShootEvent(EnemyReleaseTracker enemy) 
    {
        if (enemy.TryGetComponent<EnemyDamageDealer>(out EnemyDamageDealer enemyShooter)) 
        {
            enemyShooter.ProjectileShot += SpawnProjectile;        
        }            
    }

    private void UnsubscribeFromShootEvent(EnemyReleaseTracker enemy) 
    {
        if (enemy.TryGetComponent<EnemyDamageDealer>(out EnemyDamageDealer enemyShooter))
        {
            enemyShooter.ProjectileShot -= SpawnProjectile;
        }
    }
}
