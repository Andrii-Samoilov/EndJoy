using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class HighScoreButton : MonoBehaviour
{
    public Text[] text;
    public GameObject highscore;

    private void OnMouseDown()
    {
        StartCoroutine(GetRequest("http://localhost:63342/mysite/getHighscore.php"));

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
            Debug.Log("Received: " + uwr.downloadHandler.text);
            RootObject myObject = JsonUtility.FromJson<RootObject>("{\"highscore\":" + uwr.downloadHandler.text + "}");
            rankingMaster(myObject);
            highscore.SetActive(true);

        }
    }
    [Serializable]
    public class rank
    {
        public string login;
        public float km;
    }
    [Serializable]
    public class RootObject
    {
        public rank[] highscore;
    }

    public void rankingMaster(RootObject mas)
    {
        for (int i = 0; i < mas.highscore.Length; i++)
        {
            text[i].text = $" {mas.highscore[i].login} - {mas.highscore[i].km} km ";

        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
