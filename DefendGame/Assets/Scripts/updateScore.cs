using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class updateScore : MonoBehaviour {
    string playerName;
    private string url = "http://dreamlo.com/lb/o7YH_9SaSUayxHGKi6fDQgSmHC_qgUxkCpBTcmr3MsDQ";
    string dreamloWebserviceURL = "http://dreamlo.com/lb/";
    // List<dreamloLeaderBoard.Score> scoreList;
    dreamloLeaderBoard dl;
    bool save;
    public Text displayText;
    // Use this for initialization
    public InputField IF;
    public Font currentFont;
    bool checkUpdate;
    public struct Score
    {
        public string playerName;
        public int score;
    }

    void Start()
    {
        displayText.text = "Your current score is: " + Board.score.ToString();
        // get the reference here...
        this.dl = dreamloLeaderBoard.GetSceneDreamloLeaderboard();
        //scoreList = dl.ToListHighToLow();
    }

    void OnGUI()
    {
        // dl = dreamloLeaderBoard.GetSceneDreamloLeaderboard();
        List<dreamloLeaderBoard.Score> scoreList = dl.ToListHighToLow();
        print(scoreList.Count);
        int maxToDisplay = 20;
        int count = 0;
        GUILayoutOption[] width200 = new GUILayoutOption[] { GUILayout.Width(200) };
        GUI.skin.label.font = currentFont;
        GUI.skin.label.fontSize = 20;
        float width = 400;  // Make this wider to add more columns
        float height = 300;

        Rect r = new Rect(Screen.width/2+50, Screen.height/2-150, width, height);
        GUILayout.BeginArea(r);
        foreach (dreamloLeaderBoard.Score currentScore in scoreList)
        {
            count++;
            GUILayout.BeginHorizontal();
            GUILayout.Label(currentScore.playerName, width200);
            GUILayout.Label(currentScore.score.ToString(), width200);
            GUILayout.EndHorizontal();

            if (count >= maxToDisplay) break;
        }
        GUILayout.EndArea();
        
    }


    private void Update()
    {
        if (Button.save)
        {
            Button.save = false;
            if (dl.publicCode == "") Debug.LogError("You forgot to set the publicCode variable");
            if (dl.privateCode == "") Debug.LogError("You forgot to set the privateCode variable");
            dl.AddScore(Button.playerName, Board.score);
        }
        //dl = dreamloLeaderBoard.GetSceneDreamloLeaderboard();
        //scoreList = dl.ToListHighToLow();
        //print(scoreList.Count);
    }

}
