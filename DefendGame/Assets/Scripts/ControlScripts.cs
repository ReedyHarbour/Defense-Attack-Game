using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ControlScripts : MonoBehaviour {
    public string[] quotes = new string[10];
    public GameObject quote;
    // Use this for initialization
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        int num = Random.Range(0, 10);
        quote.GetComponent<UnityEngine.UI.Text>().text = quotes[num];
    }

    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Board.changeScene)
        {
            int num = Random.Range(0, 10);
            quote.GetComponent<UnityEngine.UI.Text>().text = quotes[num];
            Board.changeScene = false;
        }
    }
}
