using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class playerHud : MonoBehaviour {
    //public GameObject[] menus;
    public List<GameObject> menus;// = new List<GameObject>(){ GameObject.Find("QuestMenu") };


    public void Start()
    {
        menus = new List<GameObject>() { GameObject.Find("QuestMenu"), GameObject.Find("Inventory") , GameObject.Find("Spells") , GameObject.Find("Equip") , GameObject.Find("skillTree") , GameObject.Find("Quest") };
        closeAllMenu();
    }


	public void openMenu(int menuId)
    {
        closeAllMenu(); 
        menus[menuId].SetActive(true);
         
            

    }
    public void closeAllMenu()
    {
        for (int k=0;k<menus.Count;k++)
            menus[k].SetActive(false);
            
    }
    public void closeMenu (int menuId)
    {
        menus[menuId].SetActive(false);
    }
}
