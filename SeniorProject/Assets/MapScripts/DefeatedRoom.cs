using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatedRoom : MonoBehaviour
{
    PlayerAttr playerAttr;
    // Start is called before the first frame update
    void Awake()
    {
        playerAttr = GameObject.FindWithTag("Player").GetComponent<PlayerAttr>();
        SetChildrenCollidersToTrigger(false);
    }


    void FixedUpdate()
    {
        // SetChildrenCollidersToTrigger(true);
        if(playerAttr.enemiesToKilled == 0){
            SetChildrenCollidersToTrigger(true);
        }
        else{
            SetChildrenCollidersToTrigger(false);
        }
    }

    private void SetChildrenCollidersToTrigger(bool isTrigger)
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
                Debug.Log(childCollider.name + " trigger is :" + childCollider.isTrigger);
                childCollider.isTrigger = isTrigger;
                Debug.Log(childCollider.name + " trigger is :" + childCollider.isTrigger);
            }
        }
    }
}
