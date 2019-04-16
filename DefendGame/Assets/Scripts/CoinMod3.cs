using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMod3 : MonoBehaviour {

	private AudioSource source;
	public AudioClip reward;
	public AudioClip failure;

	void Start(){
		source = GetComponent<AudioSource>();
	}
	
	public void positiveCorrect () {
		if (QuizPool.answerkey[DisplayQuestion.n]) {
			HandleText.paused = false;
			source.PlayOneShot(reward, 0.8f);
			HandleText.paused = false;
			Board.coins = Board.coins + 4;
		}else{
			source.PlayOneShot(failure, 0.8f);
		}
	}

	public void negativeCorrect () {
		if (!QuizPool.answerkey[DisplayQuestion.n]) {
			HandleText.paused = false;
			source.PlayOneShot(reward, 1.5f);
			HandleText.paused = false;
			Board.coins = Board.coins + 4;
		}else{
			source.PlayOneShot(failure, 1.5f);
		}
	}
}
