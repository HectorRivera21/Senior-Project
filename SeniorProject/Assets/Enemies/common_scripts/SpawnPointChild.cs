using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointChild : MonoBehaviour
{
    SpawnPoint_E spawn_;   
    int random;
    // Start is called before the first frame update
    void Start()
    {
        random = Random.Range(0,100);
        spawn_ = GetComponentInParent<SpawnPoint_E>();
        if(random < 50){
            spawn_.SpawnSlime(gameObject.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
