using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Board : MonoBehaviour {
    public GameObject[] card_generator = new GameObject[6];
    public static bool[] has_card = new bool[6];
    public int[][] card_coolDown = new int[4][];
    public GameObject[] descriptions = new GameObject[15];
    public bool[] dragTrials = new bool[3];
    public Transform[] cards = new Transform[15];
    public static int startMode;
    public GameObject[] virus_generator = new GameObject[6];
    Scene currentScene;
    public static int numOfCards;

    public static bool generate_virus = true;
    public static float virus_time;
    public static int count_virus = 0;
    public static bool tutorial_complete = false;
    public float tutorial_time;

    public static int coins = 50;
    public static int score = 0;

    public static bool gameOver = false;
    public GameObject text;
    public GameObject panel;

    public static bool hasEnded = false;
    float startTime;
    public static bool accelerate;
    public static bool accelerated;
    public static bool reduce;
    public static bool reduced;

    public AudioClip loseSound;
    private AudioSource source;

    public static bool changeScene;
    void Start () {
        currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Tutorial") 
        {
        	startMode = 0;
        }
        if (currentScene.name == "Slow") startMode = 1;
        if (currentScene.name == "Main") startMode = 2;
        startTime = Time.time;
        numOfCards = 6;
        for (int i = 0; i < has_card.Length; i++) {
            has_card[i] = true;
        }

        card_coolDown[0] = new int[4];
        card_coolDown[1] = new int[5];
        card_coolDown[2] = new int[4];
        card_coolDown[3] = new int[2];
        source = GetComponent<AudioSource>();
        StartCoroutine(Repeat());
        StartCoroutine(UpdateCards());
    }


    // Update is called once per frame
    void Update () {
        if (gameOver && !hasEnded)
        {
            source.PlayOneShot(loseSound);
            // yield new WaitForSeconds(3.0f);
            changeScene = true;
            if (startMode == 2)
                SceneManager.LoadScene("LogIn", LoadSceneMode.Single);
            else
                SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
            gameOver = false;
            hasEnded = true;
        }
        else
        {
            if (coins < 0)
            {
                gameOver = true;
            }
            if (startMode == 2)
            {
                reduced = true;
                reduce = true;
                if (Time.time - startTime > 30 && !accelerated)
                {
                    accelerate = true;
                    accelerated = true;
                }
            }
            else if (startMode == 0 || startMode == 1)
            {
                if (Time.time - startTime > 20 && !reduced)
                {
                    reduced = true;
                    reduce = true;
                }
                if (Time.time - startTime > 40 && !accelerated)
                {
                    accelerate = true;
                    accelerated = true;
                }
                if (startMode == 0 && tutorial_complete)
                {
                	if (Time.time - tutorial_time > 2f)
                		SceneManager.LoadScene("End", LoadSceneMode.Single);
                }
            }
        }
    }

    int getIndex()
    {
        int i = Random.Range(0, 6);
        while (has_card[i])
        {
            // randomly choose an empty position
            i = Random.Range(0, 6);
        }
        return i;
    }

    IEnumerator UpdateCards()
    {
        while (!gameOver)
        {
            // if (GetComponent<HandleText>().paused) continue;
            // if (GetComponent<HandleText>().paused) yield break;
            yield return new WaitForSeconds(0.1f);
            if (!HandleText.paused)
            {
                if (numOfCards < 6)
                {
                    int i = getIndex();
                    card_generator[i].GetComponent<Generate>().generateCard();
                    has_card[i] = true;
                    numOfCards++;
                    if (!dragTrials[0])
                    {
                        dragTrials[0] = true;
                    }
                    else if (!dragTrials[1])
                    {
                        dragTrials[1] = true;
                    }
                }
                //if (!GetComponent<HandleText>().paused;
                //else yield return null;
            }
        }

    }

    IEnumerator Repeat() {
        while (!gameOver)
            if (startMode == 0)
            {
                int virus_pos = 0;
                int index = 0;
                if (count_virus < 1)
                {
                    virus_pos = 1;
                    index = 0;
                }
                else if (count_virus < 2)
                {
                    virus_pos = 4;
                    index = 0;
                }
                else if (count_virus < 3)
                {
                    virus_pos = 3;
                    index = 1;
                }
                else if (count_virus < 4)
                {
                    virus_pos = 5;
                    index = 2;
                }
                else if (count_virus > 4 && count_virus <= 5)
                {
                	tutorial_complete = true;
                	tutorial_time = Time.time;
                }

                yield return new WaitForSeconds(4f);
                if (!HandleText.paused && generate_virus && count_virus < 5)
                {
                	count_virus++;
                	if (count_virus < 5)
                	{
	                    virus_generator[virus_pos].GetComponent<VirusPos>().generateVirus(index);
	                    generate_virus = false;
	                    virus_time = Time.time;
	                }
                }
            }
            else
            { 
                int virus_pos = Random.Range(0, 6);
                int t = Random.Range(0, 10); // virus type
                yield return new WaitForSeconds(4f);
                if (!HandleText.paused)
                {
                    int index;
                    if (t < 6)
                    {
                        index = 0;
                    }
                    else if (t < 8)
                    {
                        index = 1;
                    }
                    else
                    {
                        index = 2;
                    }
                    virus_generator[virus_pos].GetComponent<VirusPos>().generateVirus(index);
                }
             }
        }
    }
