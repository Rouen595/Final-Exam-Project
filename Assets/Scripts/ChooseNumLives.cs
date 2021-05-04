// final

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseNumLives : MonoBehaviour
{
    // initialize lives in case user does not iteract with the dropdown
    public static int numLives;

    public void Start()
    {
        numLives = 1;
    }

    //public Text livesText;
    public Dropdown SelectLives;

    public void NumLives()
    {
        switch (SelectLives.value)
        {
            case 1:
                numLives = 1;
                break;
            case 2:
                numLives = 2;
                break;
            case 3:
                numLives = 3;
                break;
            case 4:
                numLives = 4;
                break;
            case 5:
                numLives = 5;
                break;
            case 6:
                numLives = 6;
                break;
            case 7:
                numLives = 7;
                break;
            case 8:
                numLives = 8;
                break;
            case 9:
                numLives = 9;
                break;

            default:
                numLives = 1;
                break;

        }
    }
}
