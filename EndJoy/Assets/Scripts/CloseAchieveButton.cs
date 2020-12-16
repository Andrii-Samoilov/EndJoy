using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseAchieveButton : MonoBehaviour
{
    public GameObject achieveMenu;
    private void OnMouseDown()
    {
        achieveMenu.SetActive(false);
    }
}
