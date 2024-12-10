using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace IRV.Scripts.Audio
{
    [Serializable]
    public class Sound
    {
        public string name; 
        public AudioClip audioClip;
    }
}