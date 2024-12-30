using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Muter : MonoBehaviour
{
    private readonly string MasterVolumeParameterName = "Master Volume";

    [SerializeField] private Button _button;
    [SerializeField] private AudioMixerGroup _mixer;

    private bool _isMuted;
    private float _currentLevel;
    private float _mutedLevel;

    private void Awake()
    {
        Init();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(SwitcMute);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(SwitcMute);
    }

    private void SwitcMute()
    {
        if (_isMuted)
        {
            _mixer.audioMixer.SetFloat(MasterVolumeParameterName, _currentLevel);
            _isMuted = false;
        }
        else
        {
            _currentLevel = GetCurrentLevel();
            _mixer.audioMixer.SetFloat(MasterVolumeParameterName, _mutedLevel);
            _isMuted = true;
        }
    }

    private void Init()
    {
        _currentLevel = GetCurrentLevel();
        _mutedLevel = -80f;
        _isMuted = _currentLevel == _mutedLevel;
    }

    private float GetCurrentLevel()
    {
        _mixer.audioMixer.GetFloat(MasterVolumeParameterName, out float currentLevel);

        return currentLevel;
    }
}
