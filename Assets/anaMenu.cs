using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class anaMenu : MonoBehaviour {

    public Text hsText;
    public Text ypText;

    void Start ()
    {
        int hs = PlayerPrefs.GetInt("enyuksekpuan");
        int ys = PlayerPrefs.GetInt("alinanPuan");

        hsText.text = hs.ToString();
        ypText.text = ys.ToString();
	}
	
	
	void Update ()
    {
		
	}

    public void oyunaGit()
    {
        SceneManager.LoadScene("gameScreen");
    }

    public void oyundanCik()
    {
        Application.Quit();
    }
}
