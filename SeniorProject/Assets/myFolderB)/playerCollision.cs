//using System.Collections;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class playerCollision : MonoBehaviour
//{
    // Start is called before the first frame update
//    private void Collision2D (Collider2D collision)
//    {
//        if (collision.transform.tag == "Enemies")
//        {
//            playerHealth.health--;
//            if(playerHealth.health <= 0) {
//                gameObject.SetActive(false);
//            } else
//            {
//                StartCoroutine(playerHurt());
//            }
//        }
//        IEnumerator playerHurt(){
//            Physics2D.GetIgnoreLayerCollision(6,8);
 //           yield return new WaitForSeconds(3);
//            Physics2D.IgnoreLayerCollision(6,8, false);
//
//    }
//}
