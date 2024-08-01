using System;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private void FixedUpdate()
    {
        transform.Translate(Vector3.left * _moveSpeed, Space.World);
    }
}
