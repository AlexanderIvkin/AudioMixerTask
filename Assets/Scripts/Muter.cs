using UnityEngine;
using UnityEngine.UI;

public class Muter : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private AudioListener _audioListener;

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
        _audioListener.enabled = !_audioListener.enabled;
    }
}
