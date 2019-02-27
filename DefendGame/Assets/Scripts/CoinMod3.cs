using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMod3 : MonoBehaviour {
	
	public void positiveCorrect () {
		if (QuizPool.answerkey[DisplayQuestion.n]) {
			Board.coins = Board.coins + 2;
		}
	}

	public void negativeCorrect () {
		if (!QuizPool.answerkey[DisplayQuestion.n]) {
			Board.coins = Board.coins + 2;
		}
	}
}
