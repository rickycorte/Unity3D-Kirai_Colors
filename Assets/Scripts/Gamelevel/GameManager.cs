using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    bool isStarted = true;

    [SerializeField] int score = 0;

	// Use this for initialization
	void Start () {

        if (isStarted)
        {
            Debug.Log("ciao il mio colore preferito e': "+ColorExtension.red);
            Debug.Log(ColorExtension.yellow+ " e' il miglior colore");
            Debug.Log("ciao " + ColorExtension.blue + ", sei bello ");
            Color c = ColorExtension.red;
            Debug.Log(c.ToString());
        }

	}
	


}
