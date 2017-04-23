using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
    void Start() {
        AkSoundEngine.SetState("PlayerSwitch", "Menu");
    }

	void Update () {
        // If anybody press A button
	    if(Input.GetButtonDown("P1Jump") || Input.GetButtonDown("P2Jump") || Input.GetButtonDown("P3Jump") || Input.GetButtonDown("P4Jump")) {
            AkSoundEngine.PostEvent("Play_Press_btn", GameObject.FindGameObjectWithTag("Wwise").gameObject);
            SceneManager.LoadScene("MenuChara");
        }

        // If anybody press B button
        if(Input.GetButtonDown("P1B") || Input.GetButtonDown("P2B") || Input.GetButtonDown("P3B") || Input.GetButtonDown("P4B")) {
            AkSoundEngine.PostEvent("Play_Press_btn", GameObject.FindGameObjectWithTag("Wwise").gameObject);
            Application.Quit();
        }

        // If anybody press X button
        if (Input.GetButtonDown("P1X") || Input.GetButtonDown("P2X") || Input.GetButtonDown("P3X") || Input.GetButtonDown("P4X")) {
            AkSoundEngine.PostEvent("Play_Press_btn", GameObject.FindGameObjectWithTag("Wwise").gameObject);
            SceneManager.LoadScene("Credits");
        }
    }
}
