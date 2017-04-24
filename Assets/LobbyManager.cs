using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour {
    public GameObject[] buttons;
    public GameObject[] robots;

    bool[] ready = new bool[4];
    int playerCount = 0;

    void Start () {
        for (int i = 0; i < 4; i++) {
            ready[i] = false;
        }
	}
	
	void Update () {
        // If anybody press A button
        if (Input.GetButtonDown("P1Jump")) {
            AkSoundEngine.PostEvent("Play_Press_btn", GameObject.FindGameObjectWithTag("Wwise").gameObject);
            buttons[0].GetComponent<Animator>().SetTrigger("Check");
            robots[0].GetComponent<Animator>().SetTrigger("Show");
            if(!ready[0]) {
                playerCount++;
                ready[0] = true;
            } else {
                playerCount--;
                ready[0] = false;
            }
        }

        if (Input.GetButtonDown("P2Jump")) {
            AkSoundEngine.PostEvent("Play_Press_btn", GameObject.FindGameObjectWithTag("Wwise").gameObject);
            buttons[1].GetComponent<Animator>().SetTrigger("Check");
            robots[1].GetComponent<Animator>().SetTrigger("Show");
            if (!ready[1]) {
                playerCount++;
                ready[1] = true;
            }
            else {
                playerCount--;
                ready[1] = false;
            }
        }

        if (Input.GetButtonDown("P3Jump")) {
            AkSoundEngine.PostEvent("Play_Press_btn", GameObject.FindGameObjectWithTag("Wwise").gameObject);
            buttons[2].GetComponent<Animator>().SetTrigger("Check");
            robots[2].GetComponent<Animator>().SetTrigger("Show");
            if (!ready[2]) {
                playerCount++;
                ready[2] = true;
            }
            else {
                playerCount--;
                ready[2] = false;
            }
        }

        if (Input.GetButtonDown("P4Jump")) {
            AkSoundEngine.PostEvent("Play_Press_btn", GameObject.FindGameObjectWithTag("Wwise").gameObject);
            buttons[3].GetComponent<Animator>().SetTrigger("Check");
            robots[3].GetComponent<Animator>().SetTrigger("Show");
            if (!ready[3]) {
                playerCount++;
                ready[3] = true;
            }
            else {
                playerCount--;
                ready[3] = false;
            }
        }

        if (Input.GetButtonDown("P1Start") || Input.GetButtonDown("P2Start") || Input.GetButtonDown("P3Start") || Input.GetButtonDown("P4Start")) {
            AkSoundEngine.PostEvent("Play_Press_btn", GameObject.FindGameObjectWithTag("Wwise").gameObject);
            if (playerCount >= 2) {
                SceneManager.LoadScene("game");
            }
        }
    }
}
