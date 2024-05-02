using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bullet;
    // public void Shoot(){
    //     Debug.Log("SHoot from position: " + transform.position);
    //     Instantiate(bullet, transform.position, Quaternion.identity);
        

       
    // }

    public void Shoot()
    {
        // Instantiate the bullet at the shootPoint's position and rotation
        GameObject bulletObject = Instantiate(bullet, transform.position, Quaternion.identity);

        // Get the direction the player is facing (right direction in 2D)
        Vector2 playerDirection = transform.right;

        // Set the bullet's direction to be the same as the player's direction
        PlayerBullet bulletz = bulletObject.GetComponent<PlayerBullet>();
        bulletz.SetDirection(playerDirection);
    }


}
