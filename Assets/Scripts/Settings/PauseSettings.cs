using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Settings
{
    public class PauseSettings: MonoBehaviour
    {
        [SerializeField] private AudioSettings _audioSettings;

        [SerializeField] private Toggle _toggleMaster;
        [SerializeField] private Toggle _toggleSound;
        [SerializeField] private Toggle _toggleMusic;

        [SerializeField] private Slider _sliderMaster;
        [SerializeField] private Slider _sliderSound;
        [SerializeField] private Slider _sliderMusic;

        private void OnEnable()
        {
            Time.timeScale = 0;
            
            _toggleMaster.isOn = Settings.AudioSettingsParameters.AudioEnabled;
            _toggleSound.isOn = Settings.AudioSettingsParameters.EffectsEnabled;
            _toggleMusic.isOn = Settings.AudioSettingsParameters.MusicEnabled;

            _sliderMaster.value = Settings.AudioSettingsParameters.MasterVolume;
            _sliderSound.value = Settings.AudioSettingsParameters.EffectsVolume;
            _sliderMusic.value = Settings.AudioSettingsParameters.MusicVolume;
        }

        private void OnDisable()
        {
            Time.timeScale = 1;
        }

        public void ToggleMaster(bool value)
        {
            _audioSettings.ToggleMaster(value);
        }
        
        public void ToggleSound(bool value)
        {
            _audioSettings.ToggleSound(value);
        }
        
        public void ToggleMusic(bool value)
        {
            _audioSettings.ToggleMusic(value);
        }

        public void ChangeVolumeMaster(float value)
        {
            _audioSettings.ChangeVolumeMaster(value);
        }

        public void ChangeVolumeSound(float value)
        {
            _audioSettings.ChangeVolumeSound(value);
        }

        public void ChangeVolumeMusic(float value)
        {
            _audioSettings.ChangeVolumeMusic(value);
        }
    }
}