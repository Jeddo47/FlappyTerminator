using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : GenericSpawner<EnemyReleaseTracker>
{
    [SerializeField] private float _spawnPointX;
    [SerializeField] private float _minSpawnPointY;
    [SerializeField] private float _maxSpawnPointY;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private float _spawnDelaySubtrahend;
    [SerializeField] private float _minSpawnDelay;
    [SerializeField] private DifficultyIncreaser _difficultyIncreaser;

    public event Action<EnemyReleaseTracker> EnemySpawned;
    public event Action<EnemyReleaseTracker> EnemyRemoved;

    private void Start()
    {
        StartCoroutine(StartSpawning());
    }

    private void OnEnable()
    {
        _difficultyIncreaser.DifficultyIncreased += IncreaseSpawnRate;
    }

    private void OnDisable()
    {
        _difficultyIncreaser.DifficultyIncreased -= IncreaseSpawnRate;
    }

    protected override void OnGet(EnemyReleaseTracker enemy)
    {
        enemy.transform.position = new Vector2(_spawnPointX, UnityEngine.Random.Range(_minSpawnPointY, _maxSpawnPointY));
        enemy.gameObject.SetActive(true);
        enemy.ReleaseStateReached += ReleaseObject;

        EnemySpawned?.Invoke(enemy);
    }

    protected override void ReleaseObject(EnemyReleaseTracker enemy)
    {
        base.ReleaseObject(enemy);

        enemy.ReleaseStateReached -= ReleaseObject;

        EnemyRemoved?.Invoke(enemy);
    }

    private IEnumerator StartSpawning()
    {
        while (true)
        {
            GetObject();

            yield return new WaitForSeconds(_spawnDelay);
        }
    }

    private void IncreaseSpawnRate()
    {
        if (_spawnDelay > _minSpawnDelay) 
        {
            _spawnDelay -= _spawnDelaySubtrahend;
        }        
    }
}
