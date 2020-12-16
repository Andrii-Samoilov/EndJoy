using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterButton : MonoBehaviour
{

    public GameObject registration;
    private void OnMouseDown()
    {      
        registration.SetActive(true);
        
    }
}
