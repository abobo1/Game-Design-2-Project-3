using UnityEngine;
using System.Collections;
using System.IO;

public class optionsData : MonoBehaviour {

    protected int musicVol, sfxVol;
    public GameObject music, sfx;
    public string[] example = {"name:aaa","class:mage" };
	void Start () {
        //saveData(); 
	}
	void saveData()
    {
        StreamWriter outfile = new StreamWriter("options.dat");
        for (int k=0;k<example.Length;k++)
        {
            outfile.WriteLine(example[k] + "\n");
            
            
        }
        outfile.Close();

    }
	// Update is called once per frame
	void Update () {
	
	}
}
