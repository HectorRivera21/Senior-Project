//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class playerHealth : MonoBehaviour
//{
//    public static int health = 3;
//    public Image[] hearts;

//    public Sprite fullHeart;
//    public Sprite emptyHeart;

//    public enemyBullet bulletBullet;
//    public enemyShooter enemyShooter;

//    private void Awake()
//    {
 //       health = 3;

//    }
//    public void TakeDamage(int damage)
//    {

//        health -= damage;
//        if (health <= 0)
//        {
//            Destroy(gameObject);
//        }
//    }

//    void Update()
//    {
//        foreach (Image img in hearts)
//        {
//            img.sprite = emptyHeart;
//        }
//        for (int i = 0; i < health; i++)
//        {
//            hearts[i].sprite = fullHeart;
//        }
 //   }
//}
