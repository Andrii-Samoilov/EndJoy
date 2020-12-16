using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseHighScoreButton : MonoBehaviour
{
    public GameObject highscore;
    private void OnMouseDown()
    {
        highscore.SetActive(false);
    }
}
