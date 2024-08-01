using System;
using UnityEngine;

public class EnemyReleaseTracker : GenericReleaseTracker<EnemyReleaseTracker, PlayerProjectile>
{
    public static event Action EnemyKilled;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);        
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);

        if (collision.gameObject.TryGetComponent<PlayerProjectile>(out _))
        {
            EnemyKilled?.Invoke();
        }        
    }
}
