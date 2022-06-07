using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.Sound
{
    public class GameSoundHandler : SoundHandler
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
        private AudioClip[] shoot;
        [SerializeField]
        private AudioClip[] hit;
        [SerializeField]
        private AudioClip[] death;
        [SerializeField]
        private AudioClip[] upgrade;
        [SerializeField]
        private AudioClip[] experience;
        [SerializeField]
        private AudioClip[] cooldown;
        [SerializeField]
        private AudioClip[] bigExplosion;

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

        public void SoundShoot()
        {
            audioSourceEffects.PlayOneShot(randomClip(shoot));
        }

        public void SoundUpgrade()
        {
            audioSourceEffects.PlayOneShot(randomClip(upgrade));
        }

        public void SoundHit()
        {
            audioSourceEffects.PlayOneShot(randomClip(hit));
        }

        public void SoundDeath()
        {
            audioSourceEffects.PlayOneShot(randomClip(death));
        }

        public void SoundExperience()
        {
            audioSourceEffects.PlayOneShot(randomClip(experience));
        }

        public void SoundCooldown()
        {
            audioSourceUI.PlayOneShot(randomClip(cooldown));
        }

        public void SoundBigExplosion()
        {
            audioSourceUI.PlayOneShot(randomClip(bigExplosion));
        }

        private AudioClip randomClip(AudioClip[] clips)
        {
            return clips[random.Next(clips.Length)];
        }
    } 
}
