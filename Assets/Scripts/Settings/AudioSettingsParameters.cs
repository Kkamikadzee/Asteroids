using UnityEngine;

namespace Settings
{
    public class AudioSettingsParameters
    {
        private bool _audioEnabled;
        private float _masterVolume;
        
        private bool _musicEnabled;
        private float _musicVolume;
        
        private bool _effectsEnabled;
        private float _effectsVolume;

        public static bool AudioEnabled
        {
            get => AudioSettingsParametersCreator.Instance._audioEnabled;
            set
            {
                AudioSettingsParametersCreator.Instance._audioEnabled = value;
                
                PlayerPrefs.SetInt("AudioEnabled", value ? 1 : 0);
            }
        }

        public static float MasterVolume
        {
            get => AudioSettingsParametersCreator.Instance._masterVolume;
            set
            {
                AudioSettingsParametersCreator.Instance._masterVolume = value;
                
                PlayerPrefs.SetFloat("MasterVolume", value);
            }
        }

        public static bool MusicEnabled
        {
            get => AudioSettingsParametersCreator.Instance._musicEnabled;
            set
            {
                AudioSettingsParametersCreator.Instance._musicEnabled = value;
                
                PlayerPrefs.SetInt("MusicEnabled", value ? 1 : 0);
            }
        }

        public static float MusicVolume
        {
            get => AudioSettingsParametersCreator.Instance._musicVolume;
            set
            {
                AudioSettingsParametersCreator.Instance._musicVolume = value;
                
                PlayerPrefs.SetFloat("MusicVolume", value);
            }
        }

        public static bool EffectsEnabled
        {
            get => AudioSettingsParametersCreator.Instance._effectsEnabled;
            set
            {
                AudioSettingsParametersCreator.Instance._effectsEnabled = value;
                
                PlayerPrefs.SetInt("EffectsEnabled", value ? 1 : 0);
            }
        }

        public static float EffectsVolume
        {
            get => AudioSettingsParametersCreator.Instance._effectsVolume;
            set
            {
                AudioSettingsParametersCreator.Instance._effectsVolume = value;
                
                PlayerPrefs.SetFloat("EffectsVolume", value);
            }
        }

        protected AudioSettingsParameters(bool audioEnabled, float masterVolume,
            bool musicEnabled, float musicVolume,
            bool effectsEnabled, float effectsVolume)
        {
            _audioEnabled = audioEnabled;
            _masterVolume = masterVolume;
            
            _musicEnabled = musicEnabled;
            _musicVolume = musicVolume;

            _effectsEnabled = effectsEnabled;
            _effectsVolume = effectsVolume;
        }
        
        private sealed class AudioSettingsParametersCreator
        {
            private static readonly AudioSettingsParameters _instance = new AudioSettingsParameters(
                PlayerPrefs.GetInt("AudioEnabled", 1) == 1,
                PlayerPrefs.GetFloat("MasterVolume", 1), 
                PlayerPrefs.GetInt("MusicEnabled", 1) == 1,
                PlayerPrefs.GetFloat("MusicVolume", 1), 
                PlayerPrefs.GetInt("EffectsEnabled", 1) == 1,
                PlayerPrefs.GetFloat("EffectsVolume", 1));

            public static AudioSettingsParameters Instance => _instance;
        }
        
        public static float ConvertVolume(float value)
        {
            return value != 0 ? Mathf.Log(value, 1.2f) : -80f;
        }
    }
}