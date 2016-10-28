using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class playerHud : MonoBehaviour {
    //public GameObject[] menus;
    public int playerId = -1;
    public List<GameObject> menus;// = new List<GameObject>(){ GameObject.Find("QuestMenu") };
    public List<Image> buttonImages;
    
    public Sprite[] ElissaIcons,KaliIcons,BauxikIcons,ZachellionIcons,DrakelIcons,ZofeIcons;
    public void Start()
    {
        menus = new List<GameObject>() { GameObject.Find("QuestMenu"), GameObject.Find("Inventory") , GameObject.Find("Spells") , GameObject.Find("Equip") , GameObject.Find("skillTree") , GameObject.Find("Quest") };
        buttonImages = new List<Image>() { GameObject.Find("ImageButton").GetComponent<Image>(), GameObject.Find("ImageButton1").GetComponent<Image>(), GameObject.Find("ImageButton2").GetComponent<Image>(), GameObject.Find("ImageButton3").GetComponent<Image>(), GameObject.Find("ImageButton4").GetComponent<Image>(), GameObject.Find("ImageButton5").GetComponent<Image>(), GameObject.Find("ImageButton6").GetComponent<Image>(), GameObject.Find("ImageButton7").GetComponent<Image>(), GameObject.Find("ImageButton8").GetComponent<Image>(), GameObject.Find("ImageButton9").GetComponent<Image>() };
        closeAllMenu();
        if (playerId != -1)
        for (int k=0;k<ElissaIcons.Length;k++)
        {
            if (playerId == 0)
                buttonImages[k].sprite = ElissaIcons[k];
            else if (playerId == 1)
                buttonImages[k].sprite = KaliIcons[k];
            else if (playerId == 2)
                buttonImages[k].sprite = BauxikIcons[k];
            else if (playerId == 3)
                buttonImages[k].sprite = ZachellionIcons[k];
            else if (playerId == 4)
                buttonImages[k].sprite = DrakelIcons[k];
            else if (playerId == 5)
                buttonImages[k].sprite = ZofeIcons[k];
        }
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
