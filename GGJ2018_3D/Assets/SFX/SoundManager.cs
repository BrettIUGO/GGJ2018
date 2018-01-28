using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

  public AudioSource BackgroundMusic;
  public AudioSource FXSource;
  public static SoundManager instance = null;

  void Awake()
  {
    if (instance == null)
    {
      instance = this;
    }
    else if (instance != this)
    {
      Destroy(gameObject);
    }

    DontDestroyOnLoad(gameObject);
  }

  public void RandomizeSfx(params AudioClip[] clips)
  {
    int randomIndex = Random.Range(0, clips.Length);
    FXSource.clip = clips[randomIndex];
    
    if (!FXSource.isPlaying)
    {
      FXSource.Play();
    }
  }

  public void PlaySingle(AudioClip clip)
  {
    FXSource.clip = clip;

    if (!FXSource.isPlaying)
    {
      FXSource.Play();
    }
  }
}
