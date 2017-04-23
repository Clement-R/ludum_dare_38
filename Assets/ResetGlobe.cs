using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGlobe : MonoBehaviour {
    Vector3 StartPos;

    void Start() {
        StartPos = transform.position;
    }

	void Update () {
		if(transform.position.x > 11 || transform.position.x < -11 || transform.position.y < -10) {
            transform.position = StartPos;
        }
	}
}
