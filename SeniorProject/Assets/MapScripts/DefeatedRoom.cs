using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class DefeatedRoom : MonoBehaviour
{
    public bool has_changed = false;
    PlayerAttr playerAttr;
    
    void Awake()
    {
        playerAttr = GameObject.FindWithTag("Player").GetComponent<PlayerAttr>();
        SetChildrenCollidersToTrigger(false);
    }


    void FixedUpdate()
    {
        // SetChildrenCollidersToTrigger(true);
        if(playerAttr.enemiesToKilled == 0 && has_changed == false){
            SetChildrenCollidersToTrigger(true);
            has_changed = true;
            
        }
    }

    public void SetChildrenCollidersToTrigger(bool isTrigger)
    {
        // Get all child GameObjects
        foreach (Transform child in transform)
        {
            // Get the collider component attached to the child GameObject
            BoxCollider2D childCollider = child.GetComponent<BoxCollider2D>();

            // If the child has a collider component
            if (childCollider != null)
            {
                // Change the collider's isTrigger property
                childCollider.isTrigger = isTrigger;
            }
        }
    }
}
