using TMPro;
using UnityEngine;

public class BestScoreTracker : MonoBehaviour
{
    [SerializeField] private TMP_Text _bestScoreText;
    [SerializeField] private PlayerDamageTaker _playerDamageTaker;
    [SerializeField] private ScoreTracker _scoreTracker;

    private float _bestScore = 0;

    private void OnEnable()
    {
        _playerDamageTaker.GameIsOver += TrackBestScore;
    }

    private void OnDisable()
    {
        _playerDamageTaker.GameIsOver -= TrackBestScore;
    }

    private void TrackBestScore() 
    {
        if (_scoreTracker.Score > _bestScore) 
        {
            _bestScore = _scoreTracker.Score;                    
        }
        
        _bestScoreText.text = _bestScore.ToString();
    }
}
