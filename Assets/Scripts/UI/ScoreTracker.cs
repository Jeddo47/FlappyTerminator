using TMPro;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreDisplay;

    private float _score;

    private void OnEnable()
    {
        EnemyReleaseTracker.EnemyKilled += AddScore;
    }

    private void OnDisable()
    {
        EnemyReleaseTracker.EnemyKilled -= AddScore;
    }

    private void AddScore() 
    {
        _score++;
        
        _scoreDisplay.text = _score.ToString();
    }
}
