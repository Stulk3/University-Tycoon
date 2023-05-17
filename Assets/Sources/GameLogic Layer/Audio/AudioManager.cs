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

    // �������� ����� ���������� ���������
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
        // ��������� �����-����� � AudioClip ��� ����� ������ � ������
        musicSource.clip = _musicClip;

        PlayMusic();
    }

    // ����� ��� ������� ������
    public void PlayMusic()
    {
        musicSource.Play();
        Debug.Log("Music");
    }

    // ����� ��� ��������� ������
    public void StopMusic()
    {
        StartCoroutine(FadeOut(musicSource));
    }

    // ����� ��� ������������ ������
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

    // ����� ��� ��������� ������
    public void StopSound()
    {
        soundSource.Stop();
    }

    // ����� ��� ��������� �����
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