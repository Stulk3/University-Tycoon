using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private AudioClip _musicClip;
    [SerializeField] private AudioClip _penSoundClip;
    [SerializeField] private AudioClip _trashSoundClip;

    public static AudioClip penSound => instance._penSoundClip;
    public static AudioClip trashSound => instance._trashSoundClip;


    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource soundSource;

    // Задержка перед остановкой источника
    private const float fadeOutDuration = 1f;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        // Загрузите аудио-файлы в AudioClip для нашей музыки и звуков
        musicSource.clip = _musicClip;

        PlayMusic();
    }

    // метод для запуска музыки
    public void PlayMusic()
    {
        musicSource.Play();
        Debug.Log("Music");
    }

    // метод для остановки музыки
    public void StopMusic()
    {
        StartCoroutine(FadeOut(musicSource));
    }

    // метод для проигрывания звуков
    public void PlaySound(AudioClip clip)
    {
        if (soundSource.clip != clip)
        {
            StopSound();
            soundSource.clip = clip;
        }
        soundSource.Play();
        Debug.Log("Sound");
    }

    // метод для остановки звуков
    public void StopSound()
    {
        soundSource.Stop();
    }

    // метод для затухания звука
    private IEnumerator FadeOut(AudioSource audioSource)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / fadeOutDuration;
            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }
}