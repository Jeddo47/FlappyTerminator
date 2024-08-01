using UnityEngine;

public class PlayerProjectileSpawner : GenericSpawner<PlayerProjectileReleaseTracker>
{
    [SerializeField] private PlayerDamageDealer _playerDamageDealer;

    private void OnEnable()
    {
        _playerDamageDealer.ProjectileShot += GetObject;
    }

    private void OnDisable()
    {
        _playerDamageDealer.ProjectileShot -= GetObject;
    }

    protected override void OnGet(PlayerProjectileReleaseTracker projectile)
    {
        projectile.transform.position = _playerDamageDealer.gameObject.transform.position;
        projectile.gameObject.SetActive(true);
        projectile.ReleaseStateReached += ReleaseObject;
    }

    protected override void ReleaseObject(PlayerProjectileReleaseTracker projectile) 
    {
        base.ReleaseObject(projectile);
        
        projectile.ReleaseStateReached -= ReleaseObject;
    }
}
