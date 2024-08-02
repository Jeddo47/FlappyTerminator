using UnityEngine;
using UnityEngine.UI;

public class SoundEffectsPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _enemyDeath;
    [SerializeField] private AudioSource _enemyShoot;
    [SerializeField] private AudioSource _playerDeath;
    [SerializeField] private AudioSource _playerShoot;
    [SerializeField] private AudioSource _pressButton;
    [SerializeField] private EnemyProjectileSpawner _enemyProjectileSpawner;
    [SerializeField] private PlayerDamageTaker _playerDamageTaker;
    [SerializeField] private PlayerDamageDealer _playerDamageDealer;
    [SerializeField] private Button _toggleSoundButton;
    [SerializeField] private Button _toggleMusicButton;
    [SerializeField] private Button _playGameButton;

    private void OnEnable()
    {
        EnemyReleaseTracker.EnemyKilled += PlayEnemyDeathSound;
        _enemyProjectileSpawner.ProjectileSpawned += PlayEnemyShootSound;
        _playerDamageTaker.GameIsOver += PlayPlayerDeathSound;
        _playerDamageDealer.ProjectileShot += PlayPlayerShootSound;
        _toggleSoundButton.onClick.AddListener(PlayPressButtonSound);
        _toggleMusicButton.onClick.AddListener(PlayPressButtonSound);
        _playGameButton.onClick.AddListener(PlayPressButtonSound);
    }

    private void OnDisable()
    {
        EnemyReleaseTracker.EnemyKilled -= PlayEnemyDeathSound;
        _enemyProjectileSpawner.ProjectileSpawned -= PlayEnemyShootSound;
        _playerDamageTaker.GameIsOver -= PlayPlayerDeathSound;
        _playerDamageDealer.ProjectileShot -= PlayPlayerShootSound;
        _toggleSoundButton.onClick.RemoveListener(PlayPressButtonSound);
        _toggleMusicButton.onClick.RemoveListener(PlayPressButtonSound);
        _playGameButton.onClick.RemoveListener(PlayPressButtonSound);
    }

    private void PlayEnemyDeathSound() 
    {
        PlaySound(_enemyDeath);            
    }

    private void PlayEnemyShootSound() 
    {
        PlaySound(_enemyShoot);            
    }

    private void PlayPlayerDeathSound() 
    {
        PlaySound(_playerDeath);            
    }

    private void PlayPlayerShootSound() 
    {
        PlaySound(_playerShoot);            
    }

    private void PlayPressButtonSound() 
    {
        PlaySound(_pressButton);            
    }

    private void PlaySound(AudioSource sound) 
    {
        sound.Play();    
    }
}
