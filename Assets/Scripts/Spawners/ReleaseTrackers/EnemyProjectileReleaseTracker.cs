using UnityEngine;

public class EnemyProjectileReleaseTracker : GenericReleaseTracker<EnemyProjectileReleaseTracker, PlayerMover>
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
