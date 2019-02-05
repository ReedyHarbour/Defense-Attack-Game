using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonNext : MonoBehaviour {

    public void NextScene()
    {
        SceneManager.LoadScene("Tutorial", LoadSceneMode.Single);
        Board.gameOver = false;
        Board.hasEnded = false;
        Board.startMode = 0;
        Board.score = 0;
        Board.coins = 50;
    }
}
