using System;
using System.Collections;
using UnityEngine;

public class DifficultyIncreaser : MonoBehaviour
{
    [SerializeField] private float _increaseDelay;
    [SerializeField] private float _defaultSpawnDelay;
    [SerializeField] private float _spawnDelaySubtrahend;
    [SerializeField] private float _minSpawnDelay;

    private float _currentSpawnDelay;

    public event Action<float> DifficultyChanged;

    private void Awake()
    {
        _currentSpawnDelay = _defaultSpawnDelay;

        StartCoroutine(CountTimeBeforeIncrease());
    }

    public void ResetDifficulty() 
    {
        _currentSpawnDelay = _defaultSpawnDelay;

        DifficultyChanged?.Invoke(_currentSpawnDelay);
    }

    private IEnumerator CountTimeBeforeIncrease() 
    {
        yield return new WaitForSeconds(_increaseDelay);

        if (_currentSpawnDelay > _minSpawnDelay) 
        {
            _currentSpawnDelay -= _spawnDelaySubtrahend;
        }        

        DifficultyChanged?.Invoke(_currentSpawnDelay);

        StartCoroutine(CountTimeBeforeIncrease());
    }
}
