using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Username : MonoBehaviour
{
    public Text nameText;

    // Start is called before the first frame update
    void Start()
    {
        nameText.text = Menu.username;    
    }
}
