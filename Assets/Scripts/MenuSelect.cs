using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSelect : MonoBehaviour
{
    public MenuMain menu;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit")){
            menu.PlayGame();
        }
        else if (Input.GetButtonDown("Cancel"))
        {
            menu.QuitGame();
        }
    }
}
