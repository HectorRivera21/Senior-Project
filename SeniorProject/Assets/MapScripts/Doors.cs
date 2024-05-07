using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject player = collision.gameObject;
        if(player.CompareTag("Player"))
        {
            Vector3 camera_offset = Vector3.zero;
            Vector3 player_offset = Vector3.zero;

            float player_posx = player.transform.position.x;
            float player_posy = player.transform.position.y;

            // Check player's movement direction
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            if (horizontalInput > 0)
            {
                player_offset.x = 3f;
                camera_offset.x = 10f;
            }
            else if (horizontalInput < 0)
            {
                player_offset.x = -3f;
                camera_offset.x = -10f;
            }
            else if (verticalInput > 0)
            {
                player_offset.y = 3f;
                camera_offset.y = 10f;
            }
            else if (verticalInput < 0)
            {
                player_offset.y = -3f;
                camera_offset.y = -10f;
            }

            player.transform.position = new Vector3(player_posx + player_offset.x, player_posy + player_offset.y, player.transform.position.z);
        }
        else
        {
            float player_posx = player.transform.position.x;
            float player_posy = player.transform.position.y;
            player.transform.position = new Vector3(player_posx + -3, player_posy + -3, player.transform.position.z);
        }
    }
}
