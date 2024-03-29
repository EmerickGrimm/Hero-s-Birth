﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager _audioManager;
    [Header(" 8 - фон")]
    [Header("4 - лассо 5 - антибиотик 6 - бафф 7 - удар")]
    [Header("0 - клик 1 - ускорение 2 - бактерия 3 - цепь")]
    
    [SerializeField] private AudioClip _clickAc;
    [SerializeField] private AudioClip _speedUpAc;
    [SerializeField] private AudioClip _bacteriumAc;
    [SerializeField] private AudioClip _chainAc;
    [SerializeField] private AudioClip _bacteriumAc;

    private void Awake()
    {
        _audioManager = this;
        if (PlayerPrefs.HasKey("VolumeValue"))
            SetVolue(PlayerPrefs.GetFloat("VolumeValue"));
        else
            SetVolue(1);
    }


    /// <summary>
    /// Значения для вызова звуков:
    /// 0 - клик
    /// 1 - ускорение
    /// 2 - бактерия
    /// 3 - цепь
    /// 4 - лассо
    /// 5 - антибиотик
    /// 6 - бафф
    /// 7 - удар
    /// 8 - фон
    /// </summary>
    public void PlayAudio(int numClip)
    {
        if (_audioManager._clickAc[numClip])
            _audioManager.GetComponent<AudioSource>().PlayOneShot(_audioManager._clickAc[numClip]);
    }
        
    public void SetVolue(float vol)
    {
        PlayerPrefs.SetFloat("VolumeValue", vol);
        _audioManager.GetComponent<AudioSource>().volume = vol;
    }
}
