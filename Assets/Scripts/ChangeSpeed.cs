// final
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSpeed : MonoBehaviour
{
    public static float gTime;
    public static float rTime;


    public void Start ()
    {
        gTime = 30f;
        rTime = 30f;
    }

    public void Change(float f)
    {
        GetComponent<Text>().text = f.ToString();
        gTime = f;
        rTime = f;

    }
}
