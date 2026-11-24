using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private void Awake()
    {
        instance = this;
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
