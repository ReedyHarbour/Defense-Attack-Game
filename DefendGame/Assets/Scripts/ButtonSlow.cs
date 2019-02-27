using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonSlow : MonoBehaviour {


    public void NextScene()
    {
        SceneManager.LoadScene("Slow", LoadSceneMode.Single);
        Board.gameOver = false;
        Board.hasEnded = false;
        Board.startMode = 1;
        Board.score = 0;
        Board.coins = 50;
    }
}
