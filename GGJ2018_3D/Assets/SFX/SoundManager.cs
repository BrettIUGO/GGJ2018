using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

  public AudioSource BackgroundMusic;
  public AudioSource FXSource;
  public AudioSource AttackSounds;

  public float LowPitchRange = .95f;             
  public float HighPitchRange = 1.05f;            

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

  public void RandomizeSfx(AudioSource source, AudioClip[] clips, float delay = 0f)
  {
    if (clips.Length == 0)
    {
      return;
    }

    source.clip = clips[Random.Range(0, clips.Length)];

    source.pitch = Random.Range(LowPitchRange, HighPitchRange); ;

    if (!source.isPlaying)
    {
      source.PlayDelayed(delay);
    }
  }

  public void PlaySingle(AudioSource source, AudioClip clip)
  {
    source.clip = clip;

    if (!source.isPlaying)
    {
      source.Play();
    }
  }
}
