using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private Vector3 _endPosition;
    [SerializeField] private float _moveSpeed;

    private void FixedUpdate()
    {
        SimulateMovement();
    }

    private void SimulateMovement() 
    {
        if (transform.position.x > _endPosition.x)
        {
            transform.Translate(_endPosition * _moveSpeed, Space.World);
        }
        else 
        {
            transform.position = _startPosition;                    
        }
    }    
}
