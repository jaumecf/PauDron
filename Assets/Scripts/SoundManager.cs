using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public enum FXSounds {ENCES_FX, ENDAVANT_FX, ENRERA_FX, COLISIO_FX}
    public enum Musics {MENU, GAME}

    public AudioSource asMusic, asFX;
    public bool isMusicEnabled = true;
    public bool isFXEnabled = true;
    public float musicVolume, fxVolume;
    public AudioClip menuMusic, gameMusic;
    public AudioClip dronEncesFX, dronEndavantFX, dronEnreraFX, dronColisioFX;

    void Start()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("SoundManager");
        if (objects.Length > 1)
            Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
        PlayMusic(Musics.GAME);
    }

    public void PlayMusic(Musics music)
    {
        if (isMusicEnabled)
        {
            asMusic.enabled = true;
            asMusic.loop = true;
            if (music == Musics.MENU)
                asMusic.clip = menuMusic;
            else if (music == Musics.GAME)
                asMusic.clip = gameMusic;
            asMusic.Play();
        }
    }

    public void PlayFX(FXSounds fxSound)
    {
        //if (isFXEnabled)
        //{
            asFX.enabled = true;
            asFX.loop = true;
            switch (fxSound)
            {
                case FXSounds.ENCES_FX:
                    asFX.clip = dronEncesFX;
                    break;
                case FXSounds.ENDAVANT_FX:
                    asFX.clip = dronEndavantFX;
                    break;
                case FXSounds.ENRERA_FX:
                    asFX.clip = dronEnreraFX;
                    break;
                case FXSounds.COLISIO_FX:
                    asFX.clip = dronColisioFX;
                    break;
            }
            asFX.Play();
        //}
    }

    public void stopMusic()
    {
        asMusic.Stop();
    }

    public void SetMusicEnabled(bool state)
    {
        isMusicEnabled = state;
        if (!isMusicEnabled)
            stopMusic();
        else
            PlayMusic(Musics.GAME);
    }

}
