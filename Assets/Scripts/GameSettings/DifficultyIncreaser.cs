using System;
using System.Collections;
using UnityEngine;

public class DifficultyIncreaser : MonoBehaviour
{
    [SerializeField] private float _increaseDelay;

    public event Action DifficultyIncreased;

    private void Awake()
    {
        StartCoroutine(CountTimeBeforeIncrease());        
    }

    private IEnumerator CountTimeBeforeIncrease() 
    {
        yield return new WaitForSeconds(_increaseDelay);
        
        DifficultyIncreased?.Invoke();

        StartCoroutine(CountTimeBeforeIncrease());
    }
}
