using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonQuiz : MonoBehaviour {

	public GameObject quizPage;

	public void openquiz () {
        quizPage.SetActive(true);
		HandleText.paused = true;
		DisplayQuestion.activated = true;
		DisplayQuestion.alreadyprinted = false;
	}

	public void closequiz () {
        quizPage.SetActive(false);
        HandleText.paused = false;
		DisplayQuestion.activated = false;
		DisplayQuestion.alreadyprinted = true;
	}
}
