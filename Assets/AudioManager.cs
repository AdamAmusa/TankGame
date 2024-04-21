using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

[Header("Audio Source")]
[SerializeField] public AudioSource SFX;

[Header("Audio Clips")]
public AudioClip destroy;
public AudioClip fire;



public void PlayDestroy()
{
    SFX.PlayOneShot(destroy); 
}

public void PlayFire()
{
    SFX.PlayOneShot(fire);  
    }



}
