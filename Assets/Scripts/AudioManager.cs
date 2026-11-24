using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    
    public AudioClip backgroundMusic;
    private AudioSource source;

    private void Awake()
    {
        instance = this;

        source = GetComponent<AudioSource>();
    }

    private void Start()
    {
        PlayBackgroundMusic(backgroundMusic);
    }

    private void PlayBackgroundMusic(AudioClip clip, float volume = 0.7f)
    {
        if (clip == null || source == null) return;

        source.clip = clip;
        source.volume = volume;
        source.loop = true;
        source.Play();
    }

    public void PlaySFX(AudioClip clip, float volume = 1)
    {
        StartCoroutine(PlaySFXRoutine(clip, volume));
    }

    private IEnumerator PlaySFXRoutine(AudioClip clip, float volume = 1)
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.Play();

        yield return new WaitForSeconds(audioSource.clip.length);

        Destroy(audioSource);
    }
}
