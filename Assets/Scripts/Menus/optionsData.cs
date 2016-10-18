using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class optionsData : MonoBehaviour {

    public GameObject musicVol, sfxVol,namePlate;
    protected float musicValue, sfxValue;
    protected bool namePlateValue;
    protected string ipAddress = "localhost";
	void Start () {
        loadData();  

    }
	public void saveData()
    {
        musicValue = musicVol.GetComponent<Slider>().value;
        sfxValue = sfxVol.GetComponent<Slider>().value;
        namePlateValue = namePlate.GetComponent<Toggle>().isOn;
        StreamWriter outfile = new StreamWriter("options.dat");
        outfile.WriteLine(musicValue);
        outfile.WriteLine(sfxValue);
        outfile.WriteLine(namePlateValue);




        outfile.Close();

    }
    public void loadData()
    {
        StreamReader inFile = new StreamReader("options.dat");
        musicVol.GetComponent<Slider>().value = float.Parse(inFile.ReadLine());
        musicValue = musicVol.GetComponent<Slider>().value;
        sfxVol.GetComponent<Slider>().value = float.Parse(inFile.ReadLine());
        sfxValue = sfxVol.GetComponent<Slider>().value;
        namePlate.GetComponent<Toggle>().isOn = bool.Parse(inFile.ReadLine());
        namePlateValue = namePlate.GetComponent<Toggle>().isOn;
        //ipAddress = inFile.ReadLine();

        inFile.Close();
    }
	// Update is called once per frame
    public float getMusicVal()
    {
        return musicValue;
    }
    public float getSfxVal()
    {
        return sfxValue;
    }
    public bool getNamePlateVal()
    {
        return namePlateValue;
    }
    public string getIpAddress()
    {
        return ipAddress;
    }
	void Update () {
	
	}
}
