using System;
using Audio.Music;
using UnityEngine;
using UnityEngine.Audio;

namespace Settings
{
    public class AudioSettings: MonoBehaviour
    {
        [SerializeField] private MusicSources _musicSources;

        [SerializeField] private AudioMixer _mixer;

        public void Initialize()
        {
            ToggleMaster(AudioSettingsParameters.AudioEnabled);
            ToggleSound(AudioSettingsParameters.EffectsEnabled);
            ToggleMusic(AudioSettingsParameters.MusicEnabled);
        }
        
        public void ToggleMaster(bool value)
        {
            AudioSettingsParameters.AudioEnabled = value;
            if (value)
            {
                var kek =
                _mixer.SetFloat("MasterVolume",
                    AudioSettingsParameters.ConvertVolume(AudioSettingsParameters.MasterVolume));
            }
            else
            {
                _mixer.SetFloat("MasterVolume",
                    -80f);
            }
        }
        
        public void ToggleSound(bool value)
        {
            AudioSettingsParameters.EffectsEnabled = value;
            if (value)
            {
                _mixer.SetFloat("EffectsVolume",
                    AudioSettingsParameters.ConvertVolume(AudioSettingsParameters.EffectsVolume));
            }
            else
            {
                _mixer.SetFloat("EffectsVolume",
                    -80f);
            }
        }
        
        public void ToggleMusic(bool value)
        {
            AudioSettingsParameters.MusicEnabled = value;
            if (value)
            {
                _mixer.SetFloat("MusicVolume",
                    AudioSettingsParameters.ConvertVolume(AudioSettingsParameters.MusicVolume));
                
                _musicSources.Background.Play();
            }
            else
            {
                _mixer.SetFloat("MusicVolume",
                    -80f);                
                
                _musicSources.Background.Stop();
            }
        }

        public void ChangeVolumeMaster(float value)
        {
            AudioSettingsParameters.MasterVolume = value;

            if (AudioSettingsParameters.AudioEnabled)
            {
                _mixer.SetFloat("MasterVolume",
                    AudioSettingsParameters.ConvertVolume(AudioSettingsParameters.MasterVolume));
            }
        }

        public void ChangeVolumeSound(float value)
        {
            AudioSettingsParameters.EffectsVolume = value;

            if (AudioSettingsParameters.EffectsEnabled)
            {
                _mixer.SetFloat("EffectsVolume",
                    AudioSettingsParameters.ConvertVolume(AudioSettingsParameters.EffectsVolume));
            }
        }

        public void ChangeVolumeMusic(float value)
        {
            AudioSettingsParameters.MusicVolume = value;

            if (AudioSettingsParameters.MusicEnabled)
            {
                _mixer.SetFloat("MusicVolume",
                    AudioSettingsParameters.ConvertVolume(AudioSettingsParameters.MusicVolume));
            }
        }

    }
}