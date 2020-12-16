using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class registr : MonoBehaviour
{
    public Text loginText, passwordText, nameText,surnameText;
    public class User
    {
        public string login;
        public string password;
        public string name;
        public string surname;

    }
    private void OnMouseDown()
    {
        User userInstance = new User();
        userInstance.login = loginText.text;
        userInstance.password = passwordText.text;
        userInstance.name = nameText.text;
        userInstance.surname = surnameText.text;
        string userToJson = JsonUtility.ToJson(userInstance);
        print(userToJson);
        StartCoroutine(PostRequest("https://webapplication6-up3.conveyor.cloud/api/registration", userToJson));

    }

    IEnumerator PostRequest(string url, string json)
    {
        var uwr = new UnityWebRequest(url, UnityWebRequest.kHttpVerbPOST);
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        uwr.uploadHandler = new UploadHandlerRaw(jsonToSend);
        uwr.downloadHandler = new DownloadHandlerBuffer();
        uwr.SetRequestHeader("Content-Type", "application/json");

        //Send the request then wait here until it returns
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Received: " + uwr.downloadHandler.text);

        }
  
    }
}
