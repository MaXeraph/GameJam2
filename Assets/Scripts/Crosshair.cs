using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    public Image img;

    void Start()
    {
        img = GetComponent<Image>();
        //set_color(true);
    }

 

    public void set_color(bool hit)
    {
        if (hit) { img.color = Color.red; }
        else { img.color = Color.green;  }
    }


}
