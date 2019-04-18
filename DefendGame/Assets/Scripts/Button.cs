using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Button : MonoBehaviour {
    public static string playerName;
    public InputField IF;
    public static bool save;
    public void MainScene()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
        Board.gameOver = false;
        Board.hasEnded = false;
        Board.startMode = 2;
        Board.score = 0;
        Board.coins = 50;
    }
    public void SlowScene()
    {
        SceneManager.LoadScene("Slow", LoadSceneMode.Single);
        Board.gameOver = false;
        Board.hasEnded = false;
        Board.startMode = 1;
        Board.score = 0;
        Board.coins = 50;
    }
    public void TutorialScene()
    {
        SceneManager.LoadScene("Tutorial", LoadSceneMode.Single);
        Board.gameOver = false;
        Board.hasEnded = false;
        Board.startMode = 1;
        Board.score = 0;
        Board.coins = 50;
        Board.count_virus = 0;
        Board.generate_virus = true;
        Board.tutorial_complete = false;
    }

    public void saveName()
    {
        if (IF.text != "")
        {
            playerName = IF.text;
            save = true;
            // scoreList = dl.ToListHighToLow();
            
        }

    }
}
