using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public int coeff;
    public GameObject world;

    public GameObject pivotPointZRight;
    public GameObject pivotPointZLeft;
    public GameObject pivotPointZCenter;

    void Update () {
        // X axis rotation
        if (Input.GetAxisRaw("Vertical_right") < 0 && pivotPointZCenter.transform.rotation.x > -0.2) {
            pivotPointZCenter.transform.Rotate(new Vector3(-Time.deltaTime * coeff, 0, 0));
        }

        if(Input.GetAxisRaw("Vertical_right") > 0 && pivotPointZCenter.transform.rotation.x < 0.2) {
            pivotPointZCenter.transform.Rotate(new Vector3(Time.deltaTime * coeff, 0, 0));
        }

        // Z axis rotation
        if (Input.GetAxisRaw("Horizontal_right") > 0 && pivotPointZCenter.transform.rotation.x < 0.2) {
            pivotPointZCenter.transform.Rotate(new Vector3(0, 0, -Time.deltaTime * coeff));
        }
        else if (Input.GetAxisRaw("Horizontal_right") < 0 && pivotPointZCenter.transform.rotation.x > -0.2) {
            pivotPointZCenter.transform.Rotate(new Vector3(0, 0, Time.deltaTime * coeff));
        }

        // X axis translation
        if (Input.GetAxisRaw("Horizontal") > 0 && pivotPointZCenter.transform.position.x < 6) {
            pivotPointZCenter.transform.Translate(new Vector3(Time.deltaTime * coeff / 10, 0, 0), Space.World);
        } else if(Input.GetAxisRaw("Horizontal") < 0 && pivotPointZCenter.transform.position.x > -6) {
            pivotPointZCenter.transform.Translate(new Vector3(-Time.deltaTime * coeff / 10, 0, 0), Space.World);
        }

        if(pivotPointZCenter.transform.position.x > 6) {
            pivotPointZCenter.transform.position = new Vector3(6, pivotPointZCenter.transform.position.y, pivotPointZCenter.transform.position.z);
        } else if (pivotPointZCenter.transform.position.x < -6) {
            pivotPointZCenter.transform.position = new Vector3(-6, pivotPointZCenter.transform.position.y, pivotPointZCenter.transform.position.z);
        }

        // Y axis translation
        if (Input.GetAxisRaw("Vertical") > 0) {
            pivotPointZCenter.transform.Translate(new Vector3(0, Time.deltaTime * coeff / 10, 0), Space.World);
        } else if (Input.GetAxisRaw("Vertical") < 0) {
            pivotPointZCenter.transform.Translate(new Vector3(0, -Time.deltaTime * coeff / 10, 0), Space.World);
        }

        if (pivotPointZCenter.transform.position.y > 10) {
            pivotPointZCenter.transform.position = new Vector3(pivotPointZCenter.transform.position.x, 10, pivotPointZCenter.transform.position.z);
        } else if (pivotPointZCenter.transform.position.y < 4) {
            pivotPointZCenter.transform.position = new Vector3(pivotPointZCenter.transform.position.x, 4, pivotPointZCenter.transform.position.z);
        }
    }
}
