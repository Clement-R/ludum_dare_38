using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	void Update () {
	    if(Input.GetAxisRaw("Horizontal") > 0) {
            Debug.Log(Input.GetAxisRaw("Horizontal"));
        } else if(Input.GetAxisRaw("Horizontal") < 0) {
            Debug.Log(Input.GetAxisRaw("Horizontal"));
        }

        if (Input.GetAxisRaw("Vertical") > 0) {
            Debug.Log(Input.GetAxisRaw("Vertical"));
        }
        else if (Input.GetAxisRaw("Vertical") < 0) {
            Debug.Log(Input.GetAxisRaw("Vertical"));
        }
    }
}
