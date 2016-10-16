using UnityEngine;
using System.Collections;

public class mainMenu : MonoBehaviour {
    public GameObject[] mainButtons,optionButtons,gameMenu;
    public GameObject[] buttonFrames;
    

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
        {
            buttonFrames[1].SetActive(true);
            buttonFrames[0].SetActive(false);
            for (int k = 0; k < optionButtons.Length; k++)
                optionButtons[k].SetActive(true);
        }
        else if (name == "Return")
        {
            buttonFrames[0].SetActive(true);
            buttonFrames[1].SetActive(false);
            for (int k = 0; k < mainButtons.Length; k++)
                mainButtons[k].SetActive(true);
            for (int k = 0; k < optionButtons.Length; k++)
                optionButtons[k].SetActive(false);
            for (int k = 0; k < gameMenu.Length; k++)
                gameMenu[k].SetActive(false);
        }
        else if (name == "Continue" || name == "New")
        {
            buttonFrames[0].SetActive(true);
            buttonFrames[1].SetActive(false);
            for (int k = 0; k < gameMenu.Length; k++)
                gameMenu[k].SetActive(true);
        }



    }

	
}
