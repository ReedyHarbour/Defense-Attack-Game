using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizPool : MonoBehaviour {
	public static string[] quizzes;
	public static bool[] answerkey;

	void Start () {
		quizzes = new string[15];
		answerkey = new bool[15];
		quizzes[0] = "Someone stole your NetID username and password. \n You have NetID Two-Factor Authentication set up on your phone. \n Can the person still get in to your account?";
		answerkey[0] = false;
		quizzes[1] = "Is the password ABCDEFG stronger than fdSaqQp^^^7771%&AB$D?";
		answerkey[1] = false;
		quizzes[2] = "Is it true that downloading spyware doesn't introduce danger to your computer?";
		answerkey[2] = false;
		quizzes[3] = "It's not safe to use public wifi \n during sensitive activities on your electronic devices.";
		answerkey[3] = true;
		quizzes[4] = "Turning off GPS prevents all location tracking.";
		answerkey[4] = false;
		quizzes[5] = "A VPN (Virtual Personal Network) minimizes the risk of using insecure wifi.";
		answerkey[5] = true;
		quizzes[6] = "Should you share your password with your parents or romantic partner?";
		answerkey[6] = false;
		quizzes[7] = "Should you clear cookies in your browser?";
		answerkey[7] = true;
		quizzes[8] = "Should you use the same password across different online platforms?";
		answerkey[8] = false;
		quizzes[9] = "Cloud does not exist physically and protects your data perfectly.";
		answerkey[9] = false;
		quizzes[10] = "It's safer to use credit card for online shopping than debit card.";
		answerkey[10] = true;
		quizzes[11] = "Sites like Amazon, Twitter, Google, and so on are perfectly protected.";
		answerkey[11] = false;
		quizzes[12] = "Is it safe for you to write your password plainly down in a word file on your device?";
		answerkey[12] = false;
		quizzes[13] = "Should you click links in suspicious emails?";
		answerkey[13] = false;
		quizzes[14] = "Cybersecurity is IMPORTANT!!!";
		answerkey[14] = true;
	}
}
