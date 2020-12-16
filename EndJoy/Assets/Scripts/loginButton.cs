using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class loginButton : MonoBehaviour
{
    public Sprite logButtonStateOne, logButtonStateTwo;
    public Text loginText, passwordText;
  
    public class User
    {
        public string login;
        public string password;

    }
    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().sprite = logButtonStateTwo;
    }
    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().sprite = logButtonStateOne;
        User userInstance = new User();  
        userInstance.login = loginText.text;
        userInstance.password = passwordText.text;
        string userToJson = JsonUtility.ToJson(userInstance);
        print(userToJson);
        StartCoroutine(GetRequest("https://webapplication6-up3.conveyor.cloud/api/authorization", userToJson));

    }
    IEnumerator GetRequest(string url, string json)
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
         
            if (uwr.downloadHandler.text != "Invalid username or password")
            {
                mainApi.user = CreateFromJSON(uwr.downloadHandler.text);
                print(mainApi.user.user.Id);
                SceneManager.LoadScene(1);
            }



        }
    }
    public static UserInfo CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<UserInfo>(jsonString);
    }
}
