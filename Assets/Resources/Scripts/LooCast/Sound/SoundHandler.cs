using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace LooCast.Sound
{
    public abstract class SoundHandler : MonoBehaviour
    {
        [SerializeField]
        protected AudioMixer audioMixer;

        public virtual void Initialize()
        {
            InitializeVolume(Sound.Soundtype.Master);
            InitializeVolume(Sound.Soundtype.Music);
            InitializeVolume(Sound.Soundtype.Effects);
            InitializeVolume(Sound.Soundtype.UI);
        }

        protected virtual void InitializeVolume(Sound.Soundtype soundtype)
        {
            if (!PlayerPrefs.HasKey(soundtype.ToStringID()))
            {
                PlayerPrefs.SetFloat(soundtype.ToStringID(), 0.0f);
            }
            SetVolume(PlayerPrefs.GetFloat(soundtype.ToStringID()), soundtype);
        }

        public virtual void SetVolume(float volume, Sound.Soundtype soundtype)
        {
            audioMixer.SetFloat(soundtype.ToStringID(), volume);
        }
    } 
}
