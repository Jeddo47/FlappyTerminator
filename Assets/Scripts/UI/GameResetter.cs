using UnityEngine;

public class GameResetter : MonoBehaviour
{
    [SerializeField] private Canvas _mainMenu;
    [SerializeField] private PlayButtonEnabler _playButtonEnabler;
    [SerializeField] private PlayerDamageTaker _playerDamageTaker;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private EnemyProjectileSpawner _enemyProjectileSpawner;
    [SerializeField] private PlayerProjectileSpawner _playerProjectileSpawner;

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
    }

    private void ResetGame()
    {
        _mainMenu.gameObject.SetActive(true);
                
        _enemySpawner.ResetPool();
        _enemyProjectileSpawner.ResetPool();
        _playerProjectileSpawner.ResetPool();

        _playerDamageTaker.transform.position = _playerStartPosition;
        _playerDamageTaker.transform.rotation = _playerStartRotation;

        Time.timeScale = 0;
    }
}
