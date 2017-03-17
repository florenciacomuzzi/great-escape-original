using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnterNameScript : MonoBehaviour {

	public GoogleAnalyticsV4 googleAnalytics;

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
        ver = Version.Instance.version;
        Debug.Log("in EnterNameScript: version = " + ver);

        PlayerPrefs.SetString("CurrentPlayer", Name);
		googleAnalytics.LogEvent (new EventHitBuilder ()
			.SetEventCategory ("username")
			.SetEventAction ("Action")
			.SetEventLabel (Name)
			.SetEventValue (ver)); //When we create mode for game, it should be entered HERE
        SceneManager.LoadScene("Level1");
    }

    public void BackToTitle()
    {
        SceneManager.LoadScene("TitleScreen");
    }

}
