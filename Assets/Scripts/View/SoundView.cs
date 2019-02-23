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

        public void ShockSound()
        {
            audioSource.PlayOneShot(shock2, 15f);
        }
    }
}
