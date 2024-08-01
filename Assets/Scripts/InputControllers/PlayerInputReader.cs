using UnityEngine;

public class PlayerInputReader : MonoBehaviour
{
    private bool _isJump = false;
    private bool _isShoot = false;

    private void Update()
    {
        ReadJump();
        ReadShoot();
    }

    public bool GetIsJump() 
    {
        return GetBool(ref _isJump);
    }

    public bool GetIsShoot() 
    {
        return GetBool(ref _isShoot);    
    }

    private bool GetBool(ref bool value) 
    {
        bool valueToReurn = value;

        value = false;

        return valueToReurn;        
    }

    private void ReadJump() 
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            _isJump = true;        
        }            
    }

    private void ReadShoot() 
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            _isShoot = true;        
        }    
    }
}
