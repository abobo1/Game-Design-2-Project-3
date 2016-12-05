using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class playerHud : MonoBehaviour {
    //public GameObject[] menus;
    public int playerId = -1;
    public List<GameObject> menus;// = new List<GameObject>(){ GameObject.Find("QuestMenu") };
    public List<Image> buttonImages;
    public List<Image> resourceIcons;
    public float healthScale, manaScale;

    public Sprite[] ElissaIcons,KaliIcons,BauxikIcons,ZachellionIcons,DrakelIcons,ZofeIcons,potionIcons;
    public void Start()
    {
        //resourceIcons[0].transform.position = new Vector3(.1f,.18f,.1f);

        menus = new List<GameObject>() { GameObject.Find("QuestMenu"), GameObject.Find("Inventory") , GameObject.Find("Spells") , GameObject.Find("Equip") , GameObject.Find("skillTree") , GameObject.Find("Quest") };
        buttonImages = new List<Image>() { GameObject.Find("ImageButton").GetComponent<Image>(), GameObject.Find("ImageButton1").GetComponent<Image>(), GameObject.Find("ImageButton2").GetComponent<Image>(), GameObject.Find("ImageButton3").GetComponent<Image>(), GameObject.Find("ImageButton4").GetComponent<Image>(), GameObject.Find("ImageButton5").GetComponent<Image>(), GameObject.Find("ImageButton6").GetComponent<Image>(), GameObject.Find("ImageButton7").GetComponent<Image>(), GameObject.Find("ImageButton8").GetComponent<Image>(), GameObject.Find("ImageButton9").GetComponent<Image>() };
        closeAllMenu();
        healthScale = 135f;
        manaScale = 135f;
        resourceIcons[0].transform.position = new Vector3(390f, 135f, .1f);
        resourceIcons[1].transform.position = new Vector3(432f, 135f, .1f);


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
        for (int i = 0;i < 3;i++)
        {
            buttonImages[i + 7].sprite = potionIcons[i];
        }
    }
    void Update()
    {
        resourceIcons[0].transform.position = new Vector3(390f, healthScale, .1f);
        resourceIcons[1].transform.position = new Vector3(432f, manaScale, .1f);

    }

    public void scaleValues (string name, float value)
    {
        if (name == "Health")
        {
            healthScale -= value;
        }
        else if (name == "Mana")
        {
            manaScale -= value;
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
