using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _maxRotationY;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationY;
    [SerializeField] private float _minRotationZ;
    [SerializeField] private float _rotationSpeed;

    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    private void Awake()
    {
        _maxRotation = Quaternion.Euler(0, _maxRotationY, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, _minRotationY, _minRotationZ);
    }

    public void Jump() 
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);

        RotateHeadUp();
    }

    public void RotateHeadDown() 
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed);    
    }

    private void RotateHeadUp() 
    {                
        transform.rotation = _maxRotation;
    }
}
