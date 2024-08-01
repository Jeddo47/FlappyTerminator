using UnityEngine;

public class ProjectileMover : MonoBehaviour
{
    [SerializeField] private Vector3 _moveDirection;
    [SerializeField] private float _moveSpeed;

    private void FixedUpdate()
    {
        transform.Translate(_moveDirection * _moveSpeed, Space.World);
    }
}
