using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Creating instance of sounds from code with no effort
/// </summary>
public class SoundEffectsHelper : MonoBehaviour
{

  /// <summary>
  /// Singleton
  /// </summary>
  public static SoundEffectsHelper Instance;

  public AudioClip explosionSound;
  public AudioClip playerShotSound;
  public AudioClip enemyShotSound;

  void Start()
  {
    // Register the singleton
    if (Instance != null)
    {
      Debug.LogError("Multiple instances of SoundEffectsHelper!");
    }
    Instance = this;
  }

  public void MakeExplosionSound()
  {
    MakeSound(explosionSound);
  }

  public void MakePlayerShotSound()
  {
    MakeSound(playerShotSound);
        //Debug.Log("player");
    }

  public void MakeEnemyShotSound()
  {
    MakeSound(enemyShotSound);
        //Debug.Log("enemy");
    }

  /// <summary>
  /// Play a given sound
  /// </summary>
  /// <param name="originalClip"></param>
  private void MakeSound(AudioClip originalClip)
  {

        try
        {
            AudioSource.PlayClipAtPoint(originalClip, transform.position);
        }
        catch(Exception e)
        {
            Debug.Log(e);
        }
    
        //Debug.Log("test");
  }
}
