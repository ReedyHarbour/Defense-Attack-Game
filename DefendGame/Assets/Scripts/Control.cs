using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Control : MonoBehaviour {

      public void NextScene()
      {
            SceneManager.LoadScene("Main", LoadSceneMode.Single);
            Board.gameOver = false;
            Board.hasEnded = false;
            Board.startMode = 2;
            Board.score = 0;
            Board.coins = 30;
      }
}
