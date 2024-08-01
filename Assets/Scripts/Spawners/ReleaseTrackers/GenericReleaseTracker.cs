using System;
using UnityEngine;

public abstract class GenericReleaseTracker<TrackerType, CollisionType> : MonoBehaviour where TrackerType : MonoBehaviour where CollisionType : MonoBehaviour
{
    public event Action<TrackerType> ReleaseStateReached;

    protected virtual void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.TryGetComponent<ReleaseZone>(out _)) 
        {
            ReleaseStateReached?.Invoke(GetComponent<TrackerType>());
        }    
    }
    
    protected virtual void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.TryGetComponent<CollisionType>(out _)) 
        {
            ReleaseStateReached?.Invoke(GetComponent<TrackerType>());                    
        }            
    }
}
