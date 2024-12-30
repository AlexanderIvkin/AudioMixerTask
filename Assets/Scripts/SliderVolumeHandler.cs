using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SliderVolumeHandler : MonoBehaviour
{
    [SerializeField] private string _mixerParameterName;
    [SerializeField] private Slider _slider;
    [SerializeField] private AudioMixerGroup _mixer;

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(delegate { SetValue(); });
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(delegate { SetValue(); });
        
    }

    private void SetValue()
    {
        _mixer.audioMixer.SetFloat(_mixerParameterName, ConvertValue());
    }

    private float ConvertValue()
    {
        float factor = 20;

        return Mathf.Log10(_slider.value) * factor;
    }
}
