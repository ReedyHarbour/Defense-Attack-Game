using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayQuestion : MonoBehaviour {
	public static bool alreadyprinted;
	public static bool activated;
	public static int n;

	void Start () {
		activated = false;
		alreadyprinted = false;
		int i = Random.Range(0,15);
		n = i;
		GetComponent<UnityEngine.UI.Text>().text = QuizPool.quizzes[i];
		alreadyprinted = true;
	}

	void Update () {
		if (activated && !alreadyprinted) {
			int i = Random.Range(0,15);
			n = i;
			GetComponent<UnityEngine.UI.Text>().text = QuizPool.quizzes[i];
			alreadyprinted = true;
		}
	}
}
