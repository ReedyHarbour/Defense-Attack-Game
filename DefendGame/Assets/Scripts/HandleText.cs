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
    public int temp_virus = Board.count_virus;

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

    void TimeLine()
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
        else if (Board.count_virus - temp_virus > 0)
        {

            if (Board.count_virus >= 2 && Board.count_virus < 3)
            {
                enterText.GetComponent<UnityEngine.UI.Text>().text = "ANOTHER VIRUS COMING...";
            }
            else if (Board.count_virus >= 3 && Board.count_virus < 4)
            {
                enterText.GetComponent<UnityEngine.UI.Text>().text = "THIS VIRUS IS STRONGER...";
            }
            else if (Board.count_virus >= 4 && Board.count_virus < 5)
            {
                enterText.GetComponent<UnityEngine.UI.Text>().text = "THIS VIRUS CAN DISAPPEAR...";
            }
            else if (Board.count_virus >= 5)
            {
                enterText.GetComponent<UnityEngine.UI.Text>().text = "YOU COMPLETED THE TUTORIAL!";
            }
            if (elapsedTime - Board.virus_time > 1 && elapsedTime - Board.virus_time < 2 && Board.count_virus < 5)
            {
                paused = true;
                continueText.SetActive(true);
            }
        }
    }
}
