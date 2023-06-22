using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class AudioClipsListSO : ScriptableObject
{
    public AudioClip[] chop;
    public AudioClip[] deliveryFail;
    public AudioClip[] deliverySuccess;
    public AudioClip[] footstep;
    public AudioClip stove;
    public AudioClip[] objectPickup;
    public AudioClip[] objectDrop;
    public AudioClip[] tash;
    public AudioClip[] warning;
}
