using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Sound
{
    public class MenuSoundHandler : SoundHandler
    {
        [SerializeField]
        private AudioSource audioSourceEffects;
        [SerializeField]
        private AudioSource audioSourceMusic;
        [SerializeField]
        private AudioSource audioSourceUI;
        [SerializeField]
        private AudioClip[] backgroundMusic;
        [SerializeField]
        private AudioClip[] select;
        [SerializeField]
        private AudioClip[] click;

        private System.Random random = new System.Random();

        public override void Initialize()
        {
            base.Initialize();
            MusicBackground();
        }

        public void MusicBackground()
        {
            audioSourceMusic.clip = randomClip(backgroundMusic);
            audioSourceMusic.Play();
        }

        public void SoundSelect()
        {
            audioSourceUI.PlayOneShot(randomClip(select));
        }

        public void SoundClick()
        {
            audioSourceUI.PlayOneShot(randomClip(click));
        }

        private AudioClip randomClip(AudioClip[] clips)
        {
            return clips[random.Next(clips.Length)];
        }
    } 
}
