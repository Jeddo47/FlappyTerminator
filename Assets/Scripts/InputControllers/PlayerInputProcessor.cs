using UnityEngine;

public class PlayerInputProcessor : MonoBehaviour
{
    [SerializeField] private PlayerInputReader _playerInputReader;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private PlayerDamageDealer _playerDamageDealer;

    private void FixedUpdate()
    {
        if (_playerInputReader.GetIsJump())
        {
            _playerMover.Jump();
        }
        else 
        {
            _playerMover.RotateHeadDown();                    
        }

        if (_playerInputReader.GetIsShoot()) 
        {
            _playerDamageDealer.Shoot();                    
        }
    }
}
