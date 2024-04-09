using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianSfx : MonoBehaviour
{
    
    AudioSource src;
    public AudioClip guardian_damage;
    // Start is called before the first frame update
    void Start()
    {
        src = GetComponent<AudioSource>();
    }

    public void GuardianHit(){
        src.clip = guardian_damage;
        src.Play();
    }
}
