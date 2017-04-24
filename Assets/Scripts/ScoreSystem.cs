using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;

public class ScoreSystem : MonoBehaviour {

    public class Player {
        public float fillAmount = 1;
        public bool isActive = false;
    }

    public GameObject finalScreen;
    public Image[] scores;
    public float timeToWin = 40;
    public List<Player> players = new List<Player>();

    float unit = 0;

    void Start () {
        unit = 1 / timeToWin;

        // Get all the players
        for (int i = 0; i < 4; i++) {
            players.Add(new Player());
        }
        players[0].isActive = true;

        // Launch point system
        StartCoroutine("addPoint");
    }

    void Update() {
        for (int i = 0; i < 4; i++) {
            scores[i].fillAmount = players[i].fillAmount;
        }
    }

    public void SetActivePlayer(int playerId) {
        foreach (var player in players) {
            player.isActive = false;
        }
        players[playerId].isActive = true;
    }
	
	IEnumerator addPoint() {
        bool end = false;
        int index = 1;
        foreach (var player in players) {
            if(player.isActive) {
                player.fillAmount -= unit;

                if(player.fillAmount <= 0) {
                    finalScreen.GetComponent<Text>().text = index + " WIN";
                    finalScreen.SetActive(true);
                    end = true;
                    StartCoroutine("restartGame");
                }
            }
            index++;
        }

        if(!end) {
            yield return new WaitForSecondsRealtime(1f);
            StartCoroutine("addPoint");
        } else {
            AkSoundEngine.PostEvent("Play_Finish", gameObject);
            Time.timeScale = 0;
        }
    }

    IEnumerator restartGame() {
        yield return new WaitForSecondsRealtime(4f);
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}
