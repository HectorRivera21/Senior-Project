using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSfx : MonoBehaviour
{
    AudioSource src;
    public AudioClip slime_damage;
    // Start is called before the first frame update
    void Start()
    {
        src = GetComponent<AudioSource>();
    }

    public void SlimeHit(){
        src.clip = slime_damage;
        src.Play();
    }

    
}
