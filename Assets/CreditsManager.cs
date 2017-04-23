using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour {
    
	// Update is called once per frame
	void Update () {
        // If anybody press B button
        if (Input.GetButtonDown("P1B") || Input.GetButtonDown("P2B") || Input.GetButtonDown("P3B") || Input.GetButtonDown("P4B")) {
            AkSoundEngine.PostEvent("Play_Press_btn", GameObject.FindGameObjectWithTag("Wwise").gameObject);
            SceneManager.LoadScene("Menu");
        }
    }
}
