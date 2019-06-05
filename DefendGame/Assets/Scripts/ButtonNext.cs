using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonNext : MonoBehaviour {

    public void NextScene()
    {
    	Scene currentScene = SceneManager.GetActiveScene();
    	if (currentScene.name == "Tutorial Page")
    	{
    		SceneManager.LoadScene("Tutorial Slides", LoadSceneMode.Single);
    	}
    	else if (currentScene.name == "Tutorial Slides")
    	{
    		SceneManager.LoadScene("Tutorial Slides 1", LoadSceneMode.Single);
    	}
    	else if (currentScene.name == "Tutorial Slides 1")
    	{
    		SceneManager.LoadScene("Tutorial Slides 2", LoadSceneMode.Single);
    	}
    	else if (currentScene.name == "Tutorial Slides 2")
    	{
    		SceneManager.LoadScene("Tutorial Slides 3", LoadSceneMode.Single);
    	}
    	else if (currentScene.name == "Tutorial Slides 3")
    	{
	        SceneManager.LoadScene("Tutorial", LoadSceneMode.Single);
	        Board.gameOver = false;
	        Board.hasEnded = false;
	        Board.startMode = 0;
	        Board.score = 0;
	        Board.coins = 50;
	    }
    }
}
