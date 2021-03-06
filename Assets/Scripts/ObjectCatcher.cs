﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class ObjectCatcher : MonoBehaviour {
    Transform pickPosition;
    bool canGrab = false;
    GameObject ball = null;
    ThirdPersonUserControl controller;
    GameManager manager;

    Animator animator;

    void Awake() {
        pickPosition = transform.FindChild("Pick").transform;
        controller = GetComponent<ThirdPersonUserControl>();
        animator = GetComponent<Animator>();
    }

    public void OnTriggerEnter(Collider other) {
        if (other.tag == "Ball") {
            ball = other.gameObject;
            canGrab = true;
        }
    }

    public void OnTriggerExit(Collider other) {
        if (other.tag == "Ball") {
            canGrab = false;
        }
    }

    bool coroutineInTime = false;

    void Update() {
        if (manager == null) {
            manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        }

        bool grabIncoming = canGrab && Input.GetButtonDown("P" + controller.playerId + "B");
        animator.SetBool("grab", coroutineInTime);

        if (grabIncoming && !coroutineInTime) {
            coroutineInTime = true;

            ball.transform.parent = pickPosition;
            ball.GetComponent<SphereCollider>().isTrigger = true;
            ball.GetComponent<Rigidbody>().isKinematic = true;
            ball.transform.localPosition = Vector3.zero;

            StartCoroutine(MoveToPosition(Camera.main.transform, pickPosition.transform.position, 2, controller.playerId));
        }
    }

    public IEnumerator MoveToPosition(Transform transform, Vector3 position, float timeToMove, int playerId) {
        AkSoundEngine.PostEvent("Play_Robot_victory", gameObject);
        var currentPos = transform.position;
        var t = 0f;
        while (t < 1) {
            t += Time.deltaTime / timeToMove;
            transform.position = Vector3.Lerp(currentPos, new Vector3(position.x, position.y + 0.5f, position.z - 2), t);
            yield return null;
        }

        canGrab = true;
        manager.Reset(playerId - 1);
        coroutineInTime = false;
    }
}
