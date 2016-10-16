using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class optionsData : MonoBehaviour {

    //protected int musicVol, sfxVol;
    public GameObject musicVol, sfxVol;
    //public string[] example;// = {"name:aaa","class:mage" };
    protected float[] values;
	void Start () {
        //saveData(); 
        //values[0] = musicVol.GetComponent<Slider>().value;
        //values[1] = sfxVol.GetComponent<Slider>().value;
        loadData();  

    }
	public void saveData()
    {
        values[0] = musicVol.GetComponent<Slider>().value;
        values[1] = sfxVol.GetComponent<Slider>().value;
        StreamWriter outfile = new StreamWriter("options.dat");
        for (int k=0;k<values.Length;k++)
        {
            outfile.WriteLine(values[k] + "\n");
            
            
        }
        outfile.Close();

    }
    public void loadData()
    {
        StreamReader inFile = new StreamReader("options.dat");
        string myline;
        musicVol.GetComponent<Slider>().value = float.Parse(inFile.ReadLine());
        sfxVol.GetComponent<Slider>().value = float.Parse(inFile.ReadLine());
        inFile.Close();
    }
	// Update is called once per frame
	void Update () {
        //example[0] = music.GetComponent<Slider>().value
	
	}
}
