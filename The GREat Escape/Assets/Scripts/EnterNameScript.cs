﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnterNameScript : MonoBehaviour {
	/*
    public Text NameInputFieldText;
    public Text RequiredText;
    public int ver;

	// Use this for initialization
	void Start () {
        ver = -1;
	
	}
	
	// Update is called once per frame
	void Update () {

	}

    //Checks to see if Input is empty and shows warning sign if it is
    //Saves it in PlayerPrefs and continues to Level1 scene otherwise
    public void Continue()
    {
        string Name = NameInputFieldText.text.Trim();
        if (string.IsNullOrEmpty(Name))
        {
            RequiredText.text = "*Required";
            return;
        }

        PlayerPrefs.SetString("CurrentPlayer", Name);
        ver = Version.getVersion();
        Debug.Log("version = " + ver);
        SceneManager.LoadScene("Level1");
    }

    public void BackToTitle()
    {
        SceneManager.LoadScene("TitleScreen");
    }
    */
}
