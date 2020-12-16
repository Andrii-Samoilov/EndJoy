using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

public class mainApi : MonoBehaviour
{
    //public Text login,mainScore, dailyTask1, dailyTask2,globalTask;
    public static UserInfo user;
    public Text login;
    void Start()
    {
        
        //StartCoroutine(PostRequest("http://localhost:63342/mysite/getDailyTaskInfo.php", JsonUtility.ToJson(mainApi.user)));
        //StartCoroutine(GetRequest("http://localhost:63342/mysite/getGlobalTask.php"));
    }
    /*IEnumerator PostRequest(string url, string json)
    {
        var uwr = new UnityWebRequest(url, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        uwr.SetRequestHeader("Content-Type", "application/json");

        //Send the request then wait here until it returns
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            RootObject myObject = JsonUtility.FromJson<RootObject>("{\"dailyTask\":" + uwr.downloadHandler.text + "}");
            Debug.Log("Received: " + uwr.downloadHandler.text);
            
        }
    }

    IEnumerator GetRequest(string uri)
    {
        UnityWebRequest uwr = UnityWebRequest.Get(uri);
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            RootObject2 myObject = JsonUtility.FromJson<RootObject2>("{\"globalTask\":" + uwr.downloadHandler.text + "}");
            Debug.Log("Received: " + uwr.downloadHandler.text);
           
        }
    }
    [Serializable]
    public class GlobalTask
    {
        public float progress;
        public float goal;
     
    }
    [Serializable]
    public class RootObject2
    {
        public GlobalTask[] globalTask;
    }
    [Serializable]
    public class DailyTask
    {
        public string name;
        public float goal;
        public float progress;
    }
    [Serializable]
    public class RootObject
    {
        public DailyTask[] dailyTask;
    }
    */
}
