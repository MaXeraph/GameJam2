using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject cameraView;
    void Start()
    {
        cameraView = transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Bullet.Create(transform.forward + transform.position + new Vector3(0, -0.05f, 0), cameraView.transform.forward, 5f, 5, false);
        }

    }
}
