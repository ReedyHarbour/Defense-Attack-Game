using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMod2 : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (!QuizPool.answerkey[DisplayQuestion.n]) {
			Board.coins = Board.coins + 2;
		}
	}
}
