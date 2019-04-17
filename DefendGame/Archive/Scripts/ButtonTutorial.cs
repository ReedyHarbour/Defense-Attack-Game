using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonTutorial : MonoBehaviour {
    public GameObject descriptionBoard;
    public void TuScene()
    {
        SceneManager.LoadScene("Tutorial Page", LoadSceneMode.Single);
    }

    public void descriptionViewAll()
    {
        descriptionBoard.SetActive(true);
        HandleText.paused = true;
    }

    public void descriptionViewNone()
    {
        descriptionBoard.SetActive(false);
        HandleText.paused = false;
    }

}
