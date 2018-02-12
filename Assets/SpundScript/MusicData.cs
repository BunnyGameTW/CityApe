using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicData : MonoBehaviour {

    public AudioClip start;
    public AudioClip gaming;

    private AudioSource speaker;
    private bool isEndFadeOut = false;

    void Awake()
    {
        speaker = this.GetComponent<AudioSource>();
    }

    public void ChangeAudio()
    {
        StartCoroutine("ChangeAudioMusic");
    }

    IEnumerator ChangeAudioMusic()
    {
        while (!isEndFadeOut)
        {
            speaker.volume -= 0.05f;
            if (speaker.volume < 0.05f)
            {
                if (speaker.clip == start)
                {
                    speaker.clip = gaming;
                }
                else
                {
                    speaker.clip = start;
                }
                isEndFadeOut = true;
                speaker.Play();
            }

            yield return new WaitForSeconds(0.02f);
        }

        while (isEndFadeOut)
        {
            speaker.volume += 0.05f;
            if (speaker.volume > 0.7f)
            {
                isEndFadeOut = false;
            }

            yield return new WaitForSeconds(0.02f);
        }

        yield return 0;

    }
}
