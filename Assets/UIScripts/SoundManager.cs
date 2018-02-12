using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    private MusicData music;
    private SoundData sound;

    void Awake()
    {
        music = this.GetComponentInChildren<MusicData>();
        sound = this.GetComponentInChildren<SoundData>();
    }
    
    public void changeMusic()
    {
        music.ChangeAudio();
    }

    public void InitSoundeffect(int number)
    {
        sound.soundEffects[number].Play();
    }
}
