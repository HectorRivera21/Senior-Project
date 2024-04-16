using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Rendering;

public class ShopTriggerCollider : MonoBehaviour
{
    [SerializeField] private UI_Shop myShop;
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            Debug.Log("test");
            myShop.Show();
        } 
    }

    private void OnTriggerExit2D(Collider2D collision){
        myShop.Hide();
    }
}
