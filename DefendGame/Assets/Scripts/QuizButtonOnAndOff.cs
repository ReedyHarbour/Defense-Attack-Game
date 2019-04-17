using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizButtonOnAndOff : MonoBehaviour {
	public GameObject ButtonQuiz;
	double startTime;
	double elapsedTime;

	public void buttonhide () {
		ButtonQuiz.SetActive(false);
	}

	void Start () {
		startTime = Time.time;
		elapsedTime = 0.0;
	}

	void Update () {
		elapsedTime = Time.time - startTime;
		if (((int) elapsedTime != 0) && ((int) elapsedTime) % 15 == 0) {
			ButtonQuiz.SetActive(true);
		}
	}
}
