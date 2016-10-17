using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class optionsData : MonoBehaviour {

    public GameObject musicVol, sfxVol,namePlate;
    protected float musicValue, sfxValue;
    protected bool namePlateValue;
	void Start () {
        //saveData(); 
        //values[0] = musicVol.GetComponent<Slider>().value;
        //values[1] = sfxVol.GetComponent<Slider>().value;
        loadData();  
        //musicVol.GetComponent<Slider>().value = .5f;

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

        inFile.Close();
    }
	// Update is called once per frame
	void Update () {
	
	}
}
