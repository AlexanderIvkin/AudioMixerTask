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
        _slider.onValueChanged.AddListener(SetValue);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(SetValue); 
    }

    private void SetValue(float value)
    {
        _mixer.audioMixer.SetFloat(_mixerParameterName, ConvertValue(value));
    }

    private float ConvertValue(float value)
    {
        float factor = 20;

        return Mathf.Log10(value) * factor;
    }
}
