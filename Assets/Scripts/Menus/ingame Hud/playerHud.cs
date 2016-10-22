using UnityEngine;
using System.Collections;

public class playerHud : MonoBehaviour {
    public GameObject[] menus;
	public void openMenu(int menuId)
    {
        closeAllMenu();
        menus[menuId].SetActive(true);
         
            

    }
    public void closeAllMenu()
    {
        for (int k=0;k<menus.Length;k++)
            menus[k].SetActive(false);
            
    }
    public void closeMenu (int menuId)
    {
        menus[menuId].SetActive(false);
    }
}
