using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public int count = 0;
    public void add()
    {
        count += 1;
        GetComponent<Text>().text = count.ToString();
    }
}
