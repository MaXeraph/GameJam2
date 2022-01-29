using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Bullet.Create(transform.forward + transform.position + new Vector3(0, -0.25f, 0), transform.forward, 1f, 5, false);
        }

    }
}
