using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clip;

    void Start()
    {
        if(audioSource != null)
        {
            audioSource.loop = true;
        }
        PlayMusic(clip);
    }

    public void PlayMusic(AudioClip clip)
    {
        if(clip == null || audioSource == null) { return; }
        if(audioSource.clip == clip) { return; }

        audioSource.clip = clip;
        audioSource.Play();
    }
}
