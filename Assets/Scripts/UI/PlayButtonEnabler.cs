using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayButtonEnabler : MonoBehaviour
{
    [SerializeField] private Button _playButton;

    public event Action GameStarted;

    private void OnEnable()
    {
        _playButton.onClick.AddListener(StartGame);
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(StartGame);
    }

    private void StartGame() 
    {
        GameStarted?.Invoke();    
    }
}
