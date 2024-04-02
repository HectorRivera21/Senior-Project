using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSfx : MonoBehaviour
{
    AudioSource src;

   public AudioClip PlayerDeathSound;
   public AudioClip SwooshSound;
   public AudioClip PlayerHitSound;

   private void Start() {
    src = GetComponent<AudioSource>();
   }
    
    public void PlayerDeath(){
        Debug.Log("DEATH SOUND");
        src.clip = PlayerDeathSound;
        src.Play();
    }

    public void PlayerHit(){
        Debug.Log("Oowch");
        src.clip = PlayerHitSound;
        src.Play();
    }
    public void PlayerSwoosh(){
        Debug.Log("SWOOOSH");
        src.clip = SwooshSound;
        src.Play();
    }
}
