using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HandleText : MonoBehaviour {
    public GameObject enterText;
    public GameObject mouse;
    public GameObject warningText;
    public GameObject continueText;
    public static bool paused = false;
    // Use this for initialization
    float startTime;
    float elapsedTime;
    Scene currentScene;

	void Start () {
        currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Tutorial")
        {
            startTime = Time.time;
            enterText.SetActive(false);
            mouse.SetActive(false);
            warningText.SetActive(false);
            continueText.SetActive(false);
        }

	}
	
	// Update is called once per frame
	void Update () {
		elapsedTime = Time.time - startTime;
        if (Board.startMode != 2 && Input.GetKeyDown("space"))
        {
            paused = !paused;
            if (currentScene.name == "Tutorial")
            {
                continueText.SetActive(false);
            }
        }
        if (currentScene.name == "Tutorial")
            TimeLine();
    }

    void TimeLine ()
    {
        if (elapsedTime < 2 && elapsedTime > 0.5)
        {
            enterText.SetActive(true);
        }
        else if (elapsedTime < 5 && elapsedTime >= 2)
        {
            enterText.SetActive(true);
            mouse.SetActive(true);
            // continueText.SetActive(true);
            enterText.GetComponent<UnityEngine.UI.Text>().text = "TRY DRAGGING THE CARDS...";
        }
        else if (elapsedTime < 6 && elapsedTime > 5)
        {
            paused = true;
            continueText.SetActive(true);
            
        }
        else if (elapsedTime < 20 && elapsedTime >= 6)
        {
            if (GetComponent<Board>().dragTrials[0])
            {
                mouse.SetActive(false);
                warningText.SetActive(true);
                if (GetComponent<Board>().dragTrials[1])
                {
                    enterText.GetComponent<UnityEngine.UI.Text>().text = "BEWARE OF DIFFERENT ATTACKS.";
                    warningText.SetActive(false);
                }
                else
                {
                    enterText.GetComponent<UnityEngine.UI.Text>().text = "TRY AGAIN WITH ONLY RED ROWS.";
                }
            }
            else
            {
                enterText.GetComponent<UnityEngine.UI.Text>().text = "TRY AGAIN WITH ONLY RED ROWS.";
            }
        }
        else enterText.SetActive(false);
    }

}
