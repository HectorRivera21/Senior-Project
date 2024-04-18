using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{

    public GameObject Player;
    public DropItem test;
    // Start is called before the first frame update
    void Start()
    {
        GameObject playerClone = Instantiate(Player, new Vector3 (transform.position.x,transform.position.y, transform.position.z), transform.rotation);
        test.SetPlayerClone(playerClone);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
