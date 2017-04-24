using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class ResetGlobe : MonoBehaviour {
    Vector3 StartPos;

    void Start() {
        StartPos = transform.position;
    }

	void FixedUpdate () {
		if(transform.position.x > 11 || transform.position.x < -11 || transform.position.y < -10) {
            //transform.position = StartPos;
            int id = GetComponent<ThirdPersonUserControl>().playerId;
            transform.position = GameObject.Find("Resp").transform.position;//a la dure, on devrait prendre id
            
        }
	}
}
