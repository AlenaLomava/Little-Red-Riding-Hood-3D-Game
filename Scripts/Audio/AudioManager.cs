using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AudioManager
{
    #region Private_Variables
    private AudioSource sourceSFX;
    private AudioSource sourceMusic;
    private AudioSource sourceRandomPitchSFX;
    private float musicVolume = 1f;
    private float sfxVolume = 1f;
    [SerializeField]
    private AudioClip[] sounds;
    [SerializeField]
    private AudioClip defaultClip;
    [SerializeField]
    private AudioClip menuMusic;
    [SerializeField]
    private AudioClip gameMusic;

    #endregion

    public float MusicVolume
    {
        get { return musicVolume; }
        set
        {
            musicVolume = value;
            SourceMusic.volume = musicVolume;
        }
    }

    public float SfxVolume
    {
        get { return sfxVolume; }
        set
        {
            sfxVolume = value;
            SourceSFX.volume = sfxVolume;
            SourceRandomPitchSFX.volume = sfxVolume;
        }
    }

    public AudioSource SourceSFX
    {
        get { return sourceSFX; }
        set { sourceSFX = value; }
    }

    public AudioSource SourceRandomPitchSFX
    {
        get { return sourceRandomPitchSFX; }
        set { sourceRandomPitchSFX = value; }
    }

    public AudioSource SourceMusic
    {
        get { return sourceMusic; }
        set { sourceMusic = value; }
    }

    private AudioClip GetSound(string clipName)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == clipName)
            {
                return sounds[i];
            }
        }

        Debug.LogError("Can not find clip " + clipName);
        return defaultClip;
    }

    public void PlaySound(string clipName)
    {
        SourceSFX.PlayOneShot(GetSound(clipName), SfxVolume);
    }

    public void StopSound(string clipName)
    {
        SourceSFX.Stop();
    }


    public void PlaySoundRandomPitch(string clipName)
    {
        SourceRandomPitchSFX.pitch = Random.Range(0.7f, 1.3f);
        SourceRandomPitchSFX.PlayOneShot(GetSound(clipName), SfxVolume);
    }

    public void PlayMusic()
    {
        SourceMusic.clip = gameMusic;
        SourceMusic.volume = MusicVolume;
        SourceMusic.loop = true;
        SourceMusic.Play();
    }

    public void StopMusic()
    {
        //SourceMusic.clip = gameMusic;
        //SourceMusic.volume = MusicVolume;
        //SourceMusic.loop = true;
        SourceMusic.Stop();
    }

}

