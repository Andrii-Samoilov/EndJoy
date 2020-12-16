using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class AchieveButton : MonoBehaviour
{
    public GameObject achieveMenu;
    public GameObject[] icon;
    public Text[] text;
    public Sprite question;
    private void OnMouseDown()
    {

        StartCoroutine(PostRequest("http://localhost:63342/mysite/postAchieve.php", JsonUtility.ToJson(mainApi.user)));
    }
    [Serializable]
    public class Achieve
    {
        public string name;
        public float progress;
        public float max;
    }
    [Serializable]
    public class RootObject
    {
        public Achieve[] achieves;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    IEnumerator PostRequest(string url, string json)
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
            achieveMenu.SetActive(true);

            Debug.Log("Received: " + uwr.downloadHandler.text);
            RootObject myObject = JsonUtility.FromJson<RootObject>("{\"achieves\":" + uwr.downloadHandler.text + "}");
            achieveMaster(myObject);
        }
    }

    public void achieveMaster(RootObject mas)
    {
        for(int i = 0; i < mas.achieves.Length; i++ )
        {
            if (mas.achieves[i].progress < mas.achieves[i].max)
            {
                icon[i].GetComponent<SpriteRenderer>().sprite = question;
                text[i].text = "???";
            }

        }
    }
}
