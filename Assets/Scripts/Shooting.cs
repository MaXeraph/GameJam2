using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public Crosshair Crosshair;
    public Slider Ammo;
    public Image AmmoFill;
    GameObject cameraView;

    private float AmmoCapacity = 100;
    private float CurrentAmmo = 100;
    private double FireRate = 0.2;
    private bool Reloading = false;
    private double lastShot = 0;

    private Color ammo_col;
    private Vector4 reloadCol = new Vector4(1f, 0f, 0f, 0.5f);
   



    void Start()
    {
        ammo_col = AmmoFill.color;
        cameraView = transform.GetChild(1).gameObject;
        Cursor.lockState = CursorLockMode.Locked;
        Ammo.maxValue = AmmoCapacity;
        Ammo.value = CurrentAmmo;
    }

    void Update()
    {

        Crosshair.set_color(check_target());

        if (Input.GetKeyDown(KeyCode.R)) { Reloading = true; AmmoFill.color = reloadCol; }

        if (Input.GetMouseButton(0) && !Reloading && Time.time >= (lastShot+FireRate)) {
            Bullet.Create(Camera.main.transform.forward + Camera.main.transform.position , cameraView.transform.forward, 20f, 25, true);
            CurrentAmmo -= 10;
            Ammo.value = CurrentAmmo;
            lastShot = Time.time;
            if(CurrentAmmo < 10) { Reloading = true; AmmoFill.color = reloadCol; }
        }

        else if (Reloading)
        {
            CurrentAmmo = Mathf.MoveTowards(CurrentAmmo, AmmoCapacity, 2);
            Ammo.value = CurrentAmmo;
            if(CurrentAmmo >= AmmoCapacity) { Reloading = false; AmmoFill.color = ammo_col;  }
        }

    }

    bool check_target()
    {
        RaycastHit hit;
        Vector3 origin = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z);
        Vector3 direction = Camera.main.transform.TransformDirection(Vector3.forward);
        float distance = 500f;

        var ray_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

      

        if (Physics.Raycast(origin, direction, out hit, distance))
       // if (Physics.Raycast(origin, direction, out hit, distance))
        {
            if (hit.collider.tag == "Enemy")
            {
                Debug.DrawRay(origin, direction * distance, Color.red);
                Crosshair.set_color(true);
                return true;
            }

        }
        Crosshair.set_color(false);
        Debug.DrawRay(origin, direction * distance, Color.green);
        return false;

        //Vector3 origin = new Vector3(transform.position.x, transform.position.y - (transform.localScale.y * .5f), transform.position.z);
        //Vector3 direction = transform.TransformDirection(Vector3.forward);
        //float distance = 30f;
        //if (Physics.Raycast(origin, direction, out RaycastHit hit, distance))
        //{
            //Debug.DrawRay(origin, direction * distance, Color.red);
            //return true;

        //}
       // return false;
    }
}
