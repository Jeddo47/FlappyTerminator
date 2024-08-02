using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixerGroupMuter : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixerGroup;
    [SerializeField] private Button _toggleSoundButton;
    [SerializeField] private string _mixerGroupName;

    private float _minVolume = -80;
    private float _maxVolume = 0;
    private bool _isSoundEnabled = true;

    private void OnEnable()
    {
        _toggleSoundButton.onClick.AddListener(ToggleSound);
    }

    private void OnDisable()
    {
        _toggleSoundButton.onClick.RemoveListener(ToggleSound);
    }

    private void ToggleSound() 
    {
        _isSoundEnabled = !_isSoundEnabled;

        if (_isSoundEnabled)
        {
            _mixerGroup.audioMixer.SetFloat(_mixerGroupName, _maxVolume);
        }
        else 
        {
            _mixerGroup.audioMixer.SetFloat(_mixerGroupName, _minVolume);
        }
    }
}
