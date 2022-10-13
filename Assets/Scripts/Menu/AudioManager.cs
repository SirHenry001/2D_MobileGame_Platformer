using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager audioManager;

    public AudioSource myAudio;
    public AudioClip[] menuSounds;
    public AudioClip[] heroSounds;
    public AudioClip[] enemySounds;
    public AudioClip[] effectSounds;

    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();

        if ( audioManager == null)
        {
            DontDestroyOnLoad(gameObject);
            audioManager = this;
        }

        else if (audioManager != null)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayMenu(int trackNumber)
    {
        myAudio.PlayOneShot(menuSounds[trackNumber]);
    }

    public void PlayHero(int trackNumber)
    {
        myAudio.PlayOneShot(heroSounds[trackNumber]);
    }

    public void PlayEnemy(int trackNumber)
    {
        myAudio.PlayOneShot(enemySounds[trackNumber]);
    }

    public void PlayEffects(int trackNumber)
    {
        myAudio.PlayOneShot(effectSounds[trackNumber]);
    }

}
