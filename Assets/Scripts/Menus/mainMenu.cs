﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class mainMenu : MonoBehaviour {
    //set max player number in changePlayer()
    public GameObject mainButtons,optionButtons,gameMenu,charMenu,charmenuInfo,nameObj;
    public GameObject[] charProps,charPropPrefab;
    public string playerName; 
    public int playerId = 0;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
            mainButtons.SetActive(true);
            optionButtons.SetActive(false);
            gameMenu.SetActive(false);
            charMenu.SetActive(false);
            charmenuInfo.SetActive(false);
        changeName();
    }
    public void changeMenu(string name)
    {
            mainButtons.SetActive(false);
        if (name == "Exit")
            Application.Quit();
        else if (name == "Options")
        {
                optionButtons.SetActive(true);
        }
        else if (name == "Return")
        {
                mainButtons.SetActive(true);
                optionButtons.SetActive(false);
                gameMenu.SetActive(false);
                charMenu.SetActive(false);
                charmenuInfo.SetActive(false);
        }
        else if (name == "Continue" || name == "New")
        {
                gameMenu.SetActive(true);
        }
        else if (name == "Character")
        {
            mainButtons.SetActive(false);
            optionButtons.SetActive(false);
            gameMenu.SetActive(false);
            charMenu.SetActive(true);
            charmenuInfo.SetActive(true);
        }
        else if (name == "Play")
        {
            changeName();
            Application.LoadLevel(1);
            //GetComponent<offlineMan>().spawnPlayer(playerId,0);
            GetComponent<mainMenu>().enabled = false;
            GetComponent<optionsData>().enabled = false;
        }
        



    }
    public void changeName()
    {
        playerName = nameObj.GetComponent<Text>().text;
    }
    public void changePlayer(int id)
    {
        if (playerId >= 0 && id > 0 && playerId < charProps.Length-1)
        {
            playerId += 1;
        }
        else if (playerId > 0 && id < 0 && playerId <= charProps.Length-1)
            playerId -= 1;

        //set prop
        for (int k = 0; k < charProps.Length; k++)
        {
            charProps[k].SetActive(false);
            charPropPrefab[k].SetActive(false);
        }
        charProps[playerId].SetActive(true);
        charPropPrefab[playerId].SetActive(true);
    }

	
}
