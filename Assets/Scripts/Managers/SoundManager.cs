using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioClip _fireSound;

    private AudioSource _audioSource = null;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _fireSound = Resources.Load<AudioClip>("Sounds/Hand Gun 1");
        _audioSource.clip = _fireSound;
        _audioSource.loop = false;
        EventManager.StartListening("PlayFireSound", PlayFireSound);
    }

    void PlayFireSound()
    {
        _audioSource.Play();
    }
}
