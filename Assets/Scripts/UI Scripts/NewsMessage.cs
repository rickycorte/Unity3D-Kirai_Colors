using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NewsMessage : MonoBehaviour {

    Text message;
    float timer = 0;

    // Use this for initialization
    void Start () {
        message = GetComponent<Text>();
        StartCoroutine(RetriveMessage());
	}


    IEnumerator RetriveMessage()
    {
        bool isTimeout = false;
        WWW operation = new WWW("http://news.rickyit.ml/kirai_colors_news.html");
        Debug.Log("Retriving message...");
        while (!operation.isDone)
        {
            if (timer > 10f)
            {
                isTimeout = true;
                Debug.LogError("Connection Timeout");
                break;
            }
        }
        //yield return operation;

        Debug.Log(operation.text);
        if (operation != null && operation.error != "" && !isTimeout && operation.text != "")
        {
            message.text = operation.text;
        }
        else
        {
            message.text = "Something went wrong during connection... please try again later.";
        }
        yield return null;
    }

    void Update()
    {
        timer += Time.deltaTime;

    }

}
