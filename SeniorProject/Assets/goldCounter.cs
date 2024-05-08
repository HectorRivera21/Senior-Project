using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;

public class goldCounter : MonoBehaviour
{
    [Header("Interface")]
    [SerializeField] TextMeshProUGUI goldCount;

    private PlayerAttr myPlayer;
    private DamianMovement player;

    int currentCount;

    private void Start(){
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<DamianMovement>();
        myPlayer = player.GetComponent<PlayerAttr>();
    }

    private void Update(){
        goldCount.text = myPlayer.gold.ToString();
    }
}
