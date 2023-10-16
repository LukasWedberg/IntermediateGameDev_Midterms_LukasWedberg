using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioSource source;

    public static List<AudioClip> soundEffects = new List<AudioClip>();

    public List<AudioClip> localSoundEffects = new List<AudioClip>();

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();

        soundEffects = localSoundEffects;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
