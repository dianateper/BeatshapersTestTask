﻿using UnityEngine;

namespace Game.CodeBase.Common.Audio
{
    public class AudioHandler : IAudioHandler
    {
        private readonly AudioSource _audioSource;

        public AudioHandler(AudioSource audioSource)
        {
            _audioSource = audioSource;
        }

        public void PlayAudioClip(AudioClip audioClip)
        {
            if (audioClip == null) return;
            _audioSource.PlayOneShot(audioClip);
        }
    }
}