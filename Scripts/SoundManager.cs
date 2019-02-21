using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource efxSource;
    public AudioSource musicSource;
    public static SoundManager instance = null;
    
    //Sound Clip in one-go yay
    public AudioClip deadSound;
    public AudioClip walkSound;
    public AudioClip torchSound;
    public AudioClip repairSound;
    public AudioClip itemPickUpSound;
    public AudioClip hudSound;

    public float lowPitchRange = .95f;
    public float highPitchRange = 1.05f;

    GameObject playerObject;

    // Use this for initialization
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        //DontDestroyOnLoad(gameObject);
    }

    public void PlaySingle(AudioClip clip)
    {
        efxSource.clip = clip;
        efxSource.Play();
    }

    public void Stop(AudioClip clip)
    {
        efxSource.clip = clip;
        efxSource.Stop();
    }

    public void RandomiseSfx(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);

        efxSource.pitch = randomPitch;
        efxSource.clip = clips[randomIndex];
        efxSource.Play();
    }
}
