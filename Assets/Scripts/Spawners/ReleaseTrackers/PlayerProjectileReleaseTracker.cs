using UnityEngine;

public class PlayerProjectileReleaseTracker : GenericReleaseTracker<PlayerProjectileReleaseTracker, EnemyMover>
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
    }
}
