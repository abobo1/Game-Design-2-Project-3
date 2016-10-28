using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Items : MonoBehaviour {

    public List<item> itemList;
    public ArrayList items;
    public bool starterItems;
    public struct item
    {
        public string itemType,itemName,itemDescription;
        public int numOfItems,maxItems,itemValue,interactValue;

    }
	
    public Items(bool starterItems)
    {
        items = new ArrayList();
        item newItem = new item();
        itemList = new List<item>();
        populateItemList(newItem);
    }
    void populateItemList(item newItem)
    {
        if (starterItems)
        itemList.Add(createItem(newItem,"Useable", "Potion", "Restore 50 Hp", 5, 10, 50,50));
    }
    item createItem(item newItem,string itemType, string itemName, string itemDescription, int numOfItems,int maxItems, int itemValue,int interactValue)
    {
        newItem.itemType = itemType;
        newItem.itemName = itemName;
        newItem.itemDescription = itemDescription;
        newItem.numOfItems = numOfItems;
        newItem.maxItems = maxItems;
        newItem.itemValue = itemValue;
        newItem.interactValue = interactValue;

        return newItem;
    }

    public item getItem(string itemName)
    {
        item retrieveItem = new item();
        for (int k=0;k<itemList.Count;k++)
        {
            if (itemList[k].itemName == itemName)
                retrieveItem = itemList[k];

        }
        return retrieveItem;
    }
    public item giveItem (string itemName, int numOfItems)
    {
        item retrieveItem = new item();
        retrieveItem = getItem(itemName);
        retrieveItem.numOfItems = numOfItems;

        return retrieveItem;
    }
}
