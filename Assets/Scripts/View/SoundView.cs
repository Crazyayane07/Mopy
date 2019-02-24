using UnityEngine;
using Yarn.Unity;

namespace MOP.View
{
    public class SoundView : MonoBehaviour2
    {
        public AudioSource audioSource;

        public AudioClip chill;
        public AudioClip intense;

        public AudioClip shock1;
        public AudioClip shock2;

        public AudioClip fanfare;
        public AudioClip dead;

        public void GoIntense()
        {
            audioSource.clip = intense;
            audioSource.Play();
        }

        public void GoChill()
        {
            audioSource.clip = chill;
            audioSource.Play();
        }

        [YarnCommand("sound")]
        public void ShockSound(string text)
        {
            audioSource.PlayOneShot(shock1, 15f);
        }

        [YarnCommand("fanfare")]
        public void Fanfare(string text)
        {
            audioSource.PlayOneShot(fanfare, 5f);
        }

        public void ShockSound()
        {
            audioSource.PlayOneShot(shock2, 15f);
        }

        public void PlayDead()
        {
            audioSource.PlayOneShot(shock2, 15f);
        }
    }
}
