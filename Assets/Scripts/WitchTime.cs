using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchTime : MonoBehaviour
{
    public AudioClip timeClip;
    public KeyCode timeKey;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(timeKey))
        {
            AudioManager.instance.PlayAudio(timeClip, "witch");
                 
        }
    }
    
}
