using UnityEngine;
using System.Collections;

public class mainMenu : MonoBehaviour {
    public GameObject[] mainButtons,optionButtons,gameMenu;
    

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        for (int k = 0; k < mainButtons.Length; k++)
            mainButtons[k].SetActive(true);
        for (int k = 0; k < optionButtons.Length; k++)
            optionButtons[k].SetActive(false);
        for (int k = 0; k < gameMenu.Length; k++)
            gameMenu[k].SetActive(false);
    }
    public void changeMenu(string name)
    {
        for (int k = 0; k < mainButtons.Length; k++)
            mainButtons[k].SetActive(false);
        if (name == "Exit")
            Application.Quit();
        else if (name == "Options")
            for (int k = 0; k < optionButtons.Length; k++)
                optionButtons[k].SetActive(true);
        else if (name == "Return")
        {
            for (int k = 0; k < mainButtons.Length; k++)
                mainButtons[k].SetActive(true);
            for (int k = 0; k < optionButtons.Length; k++)
                optionButtons[k].SetActive(false);
            for (int k = 0; k < gameMenu.Length; k++)
                gameMenu[k].SetActive(false);
        }
        else if (name == "Continue" || name == "New")
        {
            for (int k = 0; k < gameMenu.Length; k++)
                gameMenu[k].SetActive(true);
        }



    }

	
}
