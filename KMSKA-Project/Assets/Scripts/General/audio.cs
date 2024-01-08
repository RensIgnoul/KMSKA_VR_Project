using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio : MonoBehaviour
{
    public AudioSource[] sources;
    private bool hasBeenCalled = false;
    // Start is called before the first frame update
    void Start()
    {
     
    }
    /*
    -----------------------------------------------------
    [0] introductie     | -- Spawn Area -- | Intro
    [1] Dark room Stems | ChatteringAudio  | Chattering
    [2] Enter Dark room | -- Room --       | Background
    [3] Gezing          | Trigger1         | Singing
    [4] Gang einde      | music            | Background
    -----------------------------------------------------
     */
    // Update is called once per frame
    void Update()
    {
        
    }
    public float remainingTime(int sourceInt = -1)
    {
        float remainingTime = 0f;
        if (sourceInt == -1)
        {
            foreach (var s in sources)
            {

                if (s.isPlaying && s != sources[1])
                {
                   // Debug.Log("audio playing: " + s);
                    remainingTime = s.clip.length - s.time;
                    break;
                }
            }
        }
        else
        {
            remainingTime = sources[sourceInt].clip.length - sources[sourceInt].time;
        }

        return remainingTime;
    }
    public void PlayBackgroundMusic()
    {
        if (!sources[2].isPlaying && hasBeenCalled==false && !sources[0].isPlaying || remainingTime() < 0.25f)
        {
            sources[2].Play();
        }
        else if(!sources[2].isPlaying && hasBeenCalled == false && sources[0].isPlaying)
        {
            StartCoroutine(PlayAfterDelay(sources[2], remainingTime(0)));
        }
        hasBeenCalled = true;
    }
 
    public void PlaySecondBackgroundMusic()
    {
        if (!sources[4].isPlaying && !sources[3].isPlaying)
        {
            Debug.Log("second background playing: ");
            sources[4].Play();
        }
        else if (!sources[4].isPlaying && sources[3].isPlaying)
        {
            StartCoroutine(PlayAfterDelay(sources[4], remainingTime(3)));
        }
        StartCoroutine(FadeOut(sources[1], 3f));
    }

    public IEnumerator PlayAfterDelay(AudioSource s, float delay)
    {
        Debug.Log("BEFORE");
        yield return new WaitForSeconds(delay-0.25f);
        s.Play();
        Debug.Log("AFTER");
    }

    public float trackTime(int num)
    {
        return sources[num].clip.length;
    }

    public void changeIfLoop(int sourceInt, bool change)
    {
        sources[sourceInt].loop = change;
    }
    IEnumerator FadeOut(AudioSource s, float fadeDuration)
    {
        // Store the initial volume of the AudioSource
        float startVolume = s.volume;

        // Calculate the rate of volume decrease per second
        float fadeSpeed = startVolume / fadeDuration;

        // Gradually decrease the volume over time
        while (s.volume > 0)
        {
            s.volume -= fadeSpeed * Time.deltaTime;
            yield return null;
        }

        // Ensure the volume is set to zero to avoid potential rounding issues
        s.volume = 0f;

        // Optionally, you can stop the music or perform other actions here
        s.Stop();
    }
}
