using UnityEngine;

public class GameResetter : MonoBehaviour
{
    [SerializeField] private Canvas _mainMenu;
    [SerializeField] private PlayButtonEnabler _playButtonEnabler;
    [SerializeField] private PlayerDamageTaker _playerDamageTaker;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private EnemyProjectileSpawner _enemyProjectileSpawner;
    [SerializeField] private PlayerProjectileSpawner _playerProjectileSpawner;
    [SerializeField] private ScoreTracker _scoreTracker;
    [SerializeField] private DifficultyIncreaser _difficultyIncreaser;
    [SerializeField] private AudioSource _musicSource;

    private Vector3 _playerStartPosition;
    private Quaternion _playerStartRotation;

    private void Awake()
    {
        Time.timeScale = 0;

        _playerStartPosition = _playerDamageTaker.transform.position;
        _playerStartRotation = _playerDamageTaker.transform.rotation;
    }

    private void OnEnable()
    {
        _playButtonEnabler.GameStarted += StartGame;
        _playerDamageTaker.GameIsOver += ResetGame;
    }

    private void OnDisable()
    {
        _playButtonEnabler.GameStarted -= StartGame;
        _playerDamageTaker.GameIsOver -= ResetGame;
    }

    private void StartGame()
    {
        _mainMenu.gameObject.SetActive(false);

        Time.timeScale = 1;

        _musicSource.Play();
    }

    private void ResetGame()
    {
        Time.timeScale = 0;

        _mainMenu.gameObject.SetActive(true); 
        
        _musicSource.Stop();
                
        ResetSpawners();
        ResetObjectsOnScene();
        ResetPlayer();
        _scoreTracker.ResetScore();
        _difficultyIncreaser.ResetDifficulty();
    }

    private void ResetSpawners() 
    {
        _enemySpawner.ResetPool();
        _enemyProjectileSpawner.ResetPool();
        _playerProjectileSpawner.ResetPool();
    }

    private void ResetObjectsOnScene() 
    {
        PlayerProjectile[] playerProjectilesOnScene = GameObject.FindObjectsOfType<PlayerProjectile>();
        EnemyProjectile[] enemyProjectilesOnScene = GameObject.FindObjectsOfType<EnemyProjectile>();
        EnemyMover[] enemiesOnScene = GameObject.FindObjectsOfType<EnemyMover>();

        foreach (var playerProjectile in playerProjectilesOnScene) 
        {
            Destroy(playerProjectile.gameObject);                    
        }

        foreach (var enemyProjectile in enemyProjectilesOnScene) 
        {
            Destroy(enemyProjectile.gameObject);                    
        }

        foreach (var enemy in enemiesOnScene) 
        {
            Destroy(enemy.gameObject);                    
        }
    }

    private void ResetPlayer() 
    {
        _playerDamageTaker.transform.position = _playerStartPosition;
        _playerDamageTaker.transform.rotation = _playerStartRotation;
    }
}
