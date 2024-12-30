using UnityEngine;
using UnityEngine.UI;

public class PlaySoundByButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private AudioSource _audioSource;

    private void OnEnable()
    {
        _button.onClick.AddListener(delegate { PlayOneShot(); });
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(delegate { PlayOneShot(); });
    }

    private void PlayOneShot()
    {
        _audioSource.PlayOneShot(_audioSource.clip);
    }
}
