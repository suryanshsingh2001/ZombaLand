using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceManager : MonoBehaviour
{
    [SerializeField]
     AudioClip[] adClips;

    AudioSource audioSource;





    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlayAudioSequentially());
    }


    IEnumerator PlayAudioSequentially()
    {
        yield return null;

       
        for (int i = 0; i < adClips.Length; i++)
        {
            audioSource.clip = adClips[i];

           
            audioSource.Play();

           
            while (audioSource.isPlaying)
            {
                yield return null;
            }

            
        }
    }
}
