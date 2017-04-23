using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class ObjectCatcher : MonoBehaviour {
    Transform pickPosition;
    bool canGrab = false;
    bool isGrabbing = false;
    GameObject ball = null;
    ThirdPersonUserControl controller;

    void Awake() {
        pickPosition = transform.FindChild("Pick").transform;
        controller = GetComponent<ThirdPersonUserControl>();
    }

    public void OnTriggerEnter(Collider other) {
        if (other.tag == "Ball") {
            Debug.Log("BALL !");
            ball = other.gameObject;
            canGrab = true;
        }
    }

    public void OnTriggerExit(Collider other) {
        if (other.tag == "Ball") {
            canGrab = false;
        }
    }

    void Update() {
        if(canGrab && Input.GetButtonDown("P" + controller.playerId + "B")) {
            ball.transform.parent = pickPosition;
            ball.GetComponent<SphereCollider>().isTrigger = true;
            ball.GetComponent<Rigidbody>().isKinematic = true;
            ball.transform.localPosition = Vector3.zero;

            isGrabbing = true;
        }
    }
}
