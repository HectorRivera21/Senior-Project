using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.transform.childCount > 0)
        {
            Destroy(other.gameObject.transform.GetChild(0).gameObject);
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
    }

}
