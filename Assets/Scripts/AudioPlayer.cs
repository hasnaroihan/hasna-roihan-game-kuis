using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public void PlayClip(AudioClip clip)
    {
        AudioManager.instance.PlaySFX(clip);
    }
}
