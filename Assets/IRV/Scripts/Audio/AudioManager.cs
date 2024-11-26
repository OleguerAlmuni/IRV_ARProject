using System;
using UnityEngine;

namespace IRV.Scripts.Audio
{
    [Serializable]
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;
        
        [SerializeField]
        private Sound[] music, sfx;

        [SerializeField] 
        private AudioSource musicSource, sfxSource;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void PlayMusic(string name)
        {
            Sound sound = Array.Find(music, x => x.name == name);

            if (sound != null)
            {
                musicSource.clip = sound.audioClip;
                musicSource.Play();
            }
            else
            {
                Debug.Log("Sound Not Found");
            }
        }

        public void PlaySound(string name)
        {
            Sound sound = Array.Find(sfx, x => x.name == name);
            
            if (sound != null)
            {
                sfxSource.PlayOneShot(sfxSource.clip);
            }
            else
            {
                Debug.Log("Sound Not Found");
            }
        }
     }
}