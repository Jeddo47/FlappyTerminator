using System;
using UnityEngine;

public class PlayerDamageTaker : MonoBehaviour
{
    public event Action GameIsOver;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyMover>(out _) || 
            collision.gameObject.TryGetComponent<EnemyProjectile>(out _) ||
            collision.gameObject.TryGetComponent<Ground>(out _)) 
        {            
            GameIsOver?.Invoke();
        }
    }
}
