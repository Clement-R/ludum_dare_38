using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class GameManager : MonoBehaviour {
    public GameObject room;
    public GameObject player;
    public List<GameObject> players = new List<GameObject>();
    public GameObject[] startPositions;
    public Material[] materials;

    Vector3 cameraPos;
    GameObject roomInstance;
    GameController gameController;
    ScoreSystem scoreSystem;

    bool sceneInitialised = false;

	void Start () {
        AkSoundEngine.SetState("PlayerSwitch", "Game");

	    if(!sceneInitialised) {
            roomInstance = Instantiate(room);
            
            for (int i = 0; i < 3; i++)
            {
                players.Add(Instantiate(player));
                players[i].transform.SetParent(startPositions[i].transform, false);
                //players[i].transform.GetChild(2).GetComponent<SkinnedMeshRenderer>().materials[1] = materials[i];
                //Material[] materiaaals = players[i].transform.GetChild(2).GetComponent<SkinnedMeshRenderer>().materials;
                //materials[1] = materials[i];
                //players[i].transform.GetChild(2).GetComponent<SkinnedMeshRenderer>().materials = materials;
                Renderer renderer = players[i].transform.GetChild(2).GetComponent<SkinnedMeshRenderer>();
                Material[] mats = renderer.materials;
                
                switch(i)
                {
                    case 0:
                        mats[1] = materials[3];
                        break;
                    case 1:
                        mats[1] = materials[1];
                        break;
                    case 2:
                        mats[1] = materials[2];
                        break;
                }

                renderer.materials = mats;

                players[i].transform.localPosition = Vector3.zero;
                players[i].GetComponent<ThirdPersonUserControl>().playerId = i + 1;

                
            }


        }

        scoreSystem = GetComponent<ScoreSystem>();
        cameraPos = Camera.main.transform.position;
    }

    void Update() {
        if(gameController == null) {
            gameController = GameObject.FindGameObjectWithTag("Controller").GetComponent<GameController>();
        }
    }

    public void Reset(int playerId) {
        Destroy(roomInstance);
        roomInstance = Instantiate(room);

        // Reset players
        int playerIndex = 1;
        for (int i = 0; i < 3; i++) {
            if(playerIndex == playerId + 1) {
                playerIndex++;
            }

            players[i].GetComponent<ThirdPersonUserControl>().playerId = playerIndex;

            Renderer renderer = players[i].transform.GetChild(2).GetComponent<SkinnedMeshRenderer>();
            Material[] mats = renderer.materials;
            mats[1] = materials[playerIndex - 1];
            renderer.materials = mats;

            players[i].transform.position = startPositions[i].transform.position;
            if(players[i].transform.FindChild("Pick").childCount != 0) {
                Destroy(players[i].transform.FindChild("Pick").GetChild(0).gameObject);
            }
            playerIndex++;
        }

        // Set new player controller
        gameController.GetComponent<GameController>().playerId = playerId + 1;
        scoreSystem.SetActivePlayer(playerId);

        Camera.main.transform.position = cameraPos;
    }
}
