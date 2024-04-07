using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCamrema : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.tag == "Player"){
            GameObject player = other.gameObject;
            // Debug.Log("DOOR: " + gameObject.tag);
            if(gameObject.tag == "DoorL"){
                Debug.Log("DOOR: " + gameObject.tag);
                player.transform.position = new Vector3(player.transform.position.x + -3f, player.transform.position.y, player.transform.position.z);
                Camera.main.transform.position = new Vector3(Camera.main.transform.position.x + -10f, Camera.main.transform.position.y, Camera.main.transform.position.z);
            }
            else if(gameObject.tag == "DoorR"){
                Debug.Log("DOOR: " + gameObject.tag);
                player.transform.position = new Vector3(player.transform.position.x + 3f, player.transform.position.y, player.transform.position.z);
                Camera.main.transform.position = new Vector3(Camera.main.transform.position.x + 10f, Camera.main.transform.position.y, Camera.main.transform.position.z);
            }
            else if(gameObject.tag == "DoorU"){
                Debug.Log("DOOR: " + gameObject.tag);
                player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 3f, player.transform.position.z);
                Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y + 10f, Camera.main.transform.position.z);
            }
            else if(gameObject.tag == "DoorD"){
                Debug.Log("DOOR: " + gameObject.tag);
                player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + -3f, player.transform.position.z);
                Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y + -10f, Camera.main.transform.position.z);
            }
        }
    }
}
