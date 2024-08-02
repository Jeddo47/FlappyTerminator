using System;
using TMPro;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreDisplay;

    private float _score;

    public float Score => _score;

    private void OnEnable()
    {
        EnemyReleaseTracker.EnemyKilled += AddScore;
    }

    private void OnDisable()
    {
        EnemyReleaseTracker.EnemyKilled -= AddScore;
    }
    public void ResetScore()
    {
        _score = 0;

        ShowScore();
    }

    private void AddScore()
    {
        _score++;

        ShowScore();
    }

    private void ShowScore() 
    {
        _scoreDisplay.text = _score.ToString();
    }
}
