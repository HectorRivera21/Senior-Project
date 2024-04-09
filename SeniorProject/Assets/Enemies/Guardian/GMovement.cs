using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMovement : MonoBehaviour
{
    public GameObject player; // Reference to the player transform
    private bool isFlipped = true; // Flag to track if the sprite is flipped

    private void Start() {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player has passed the sprite
        if(player != null && player.transform.position.x > transform.position.x && !isFlipped)
        {
            // Flip the sprite
            Flip();
        }
        else if(player != null && player.transform.position.x < transform.position.x && isFlipped){
            Flip();
        }
    }

    // Method to flip the sprite
    void Flip()
    {
        // Get the current scale
        Vector3 scale = transform.localScale;

        // Flip the scale horizontally
        scale.x *= -1;

        // Apply the new scale
        transform.localScale = scale;

        // Update the flag
        isFlipped = !isFlipped;
    }
}
