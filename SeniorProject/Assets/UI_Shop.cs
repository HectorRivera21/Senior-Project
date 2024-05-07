using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Shop : MonoBehaviour
{
    private Transform container;
    private Transform shopItemTemplate;
    public items myItemBoot;
    public items myItemHeart;
    public items myItemSword;
    public items myItemPot;
    private items boughtItem;

    public PlayerAttr myPlayer;

    private void Awake()
    {
        container = transform.Find("container");
        shopItemTemplate = container.Find("shopItemTemplate");
        shopItemTemplate.gameObject.SetActive(false);
        
    }

    private void Start()
    {
        myPlayer = GameObject.FindWithTag("Player").GetComponent<PlayerAttr>();
        CreateItemButton(myItemBoot.art, myItemBoot.itemName, myItemBoot.itemCost, 0);
        CreateItemButton(myItemHeart.art, myItemHeart.itemName, myItemHeart.itemCost, 1);
        CreateItemButton(myItemSword.art, myItemSword.itemName, myItemSword.itemCost, 2);
        CreateItemButton(myItemPot.art, myItemPot.itemName, myItemPot.itemCost, 3);
    }

    private void CreateItemButton(Sprite itemSprite, string itemName, int itemCost, int positionIndex)
    {
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        shopItemTransform.gameObject.SetActive(true);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

        float shopItemHeight = 90f;
        shopItemRectTransform.anchoredPosition = new Vector2(0, (-shopItemHeight * positionIndex));

        shopItemTransform.Find("nameText").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItemTransform.Find("costText").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());

        shopItemTransform.Find("itemImage").GetComponent<Image>().sprite = itemSprite;

        shopItemTransform.GetComponent<Button>().onClick.AddListener(() => TryBuyItem(itemCost, itemName));
    
    }

    public void TryBuyItem(int cost, string name){
        Debug.Log(name);
        if(myPlayer.gold < cost){
            Debug.Log("Not enough gold");
        } else {
            gameObject.GetComponentInChildren<DropItem>().Instant_Drop(name);
            myPlayer.gold = myPlayer.gold - cost; 
        }
    }

    public void Show(){
        gameObject.SetActive(true);
    }

    public void Hide(){
        gameObject.SetActive(false);
    }


}
