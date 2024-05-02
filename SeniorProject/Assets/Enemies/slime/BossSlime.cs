using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BossSlime : MonoBehaviour
{
    public PlayerAttr player;
    public enemeis me;
    bool can_split = true;
    bool can_split1 = true;
    int num_split = 1;
    public int ogHealth = 50;
    public int health;
    public int splitHealth;
    public GameObject SplitSlime;

    public ExpBar xpBar;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponentInParent<PlayerAttr>();
        xpBar = GameObject.Find("ExpBar").GetComponent<ExpBar>();
        health = me.health;
        splitHealth = health/2;
    }

    void Update() {
        if(health <= 0){
            exp();
            //Debug.Log("DESTROYING OBJ");
            gameObject.GetComponentInChildren<DropItem>().Drop_Item();
            player.gold += me.gold_drop;
            player.enemiesToKilled -= 1;
            player.enemiesKilled += 1;
            Destroy(gameObject);
        }
        else if(health < splitHealth && can_split == true){
            can_split = false;
            Split();
        }
        // health = me.health;
        
    }
    public void Split(){
        GameObject instantiatedObject1 = Instantiate(SplitSlime, transform.position, Quaternion.identity);
        instantiatedObject1.GetComponent<BossSlime>().health = health;
        instantiatedObject1.GetComponent<BossSlime>().splitHealth = health/2;
        Debug.Log("Split boss health : " +instantiatedObject1.GetComponent<BossSlime>().health);
        Debug.Log("Split boss split health : " +instantiatedObject1.GetComponent<BossSlime>().splitHealth);

        GameObject instantiatedObject2 = Instantiate(SplitSlime, transform.position, Quaternion.identity);
        instantiatedObject2.GetComponent<BossSlime>().health = health;
        instantiatedObject2.GetComponent<BossSlime>().splitHealth = health/2;
        Debug.Log("Split boss health : " +instantiatedObject1.GetComponent<BossSlime>().health);
        Debug.Log("Split boss split health : " +instantiatedObject1.GetComponent<BossSlime>().splitHealth);
        // GameObject instantiatedObject2 = Instantiate(SplitSlime, transform.position, Quaternion.identity);

        // instantiatedObject1.transform.localScale = new Vector3(instantiatedObject1.transform.localScale.x - .2f, instantiatedObject1.transform.localScale.y - .2f, 1);
        // instantiatedObject1.GetComponent<check>().health -= instantiatedObject1.GetComponent<check>().health/2;

        // instantiatedObject2.transform.localScale = new Vector3(instantiatedObject2.transform.localScale.x - .2f, instantiatedObject2.transform.localScale.y - .2f, 1);
        // instantiatedObject2.GetComponent<check>().health -= instantiatedObject2.GetComponent<check>().health/2;
    }
     public void e_damage(int x){
        health -= x;
    }

    void exp(){
        xpBar.SetMaxExp(player.how_exp);
        player.exp += me.exp;
        xpBar.SetExp(player.exp);
        //Debug.Log( "EXP" + player.exp);
    }
}
