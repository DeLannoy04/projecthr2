using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settingsOpener : MonoBehaviour
{
    private bool settingsMenuState = false;
    public GameObject settingsMenu;

    public void settingsMenuButton()
    {
        settingsMenuState = !settingsMenuState;
        settingsMenu.SetActive(settingsMenuState);
    }
}