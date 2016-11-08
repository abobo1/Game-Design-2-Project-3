using UnityEngine;
using System.Collections;

public class playerAttack : MonoBehaviour {


    bool toolTip = false;
    string spellName;
    float uiWidth, uiHeight;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void changeIcon(int id)
    {
        uiHeight = Screen.height - 100;
        //change pos
        if (id == 0)
            uiWidth = Screen.width - 1025;
        else if (id ==1)
            uiWidth = Screen.width - 990;
    }
    public void Hover(string spellName)
    {
        //Debug.Log(spellName);
        toolTip = true;
        this.spellName = spellName;

       
    }
    public void hideUI()
    {
        toolTip = false;
    }

    void OnGUI()
    {
        if (toolTip)
        GUI.Label(new Rect(uiWidth,uiHeight , 128, 32), spellName);
    }
    }
