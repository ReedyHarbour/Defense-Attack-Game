using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Music : MonoBehaviour {
    bool musicOn;
    public AudioClip bgSound;
    private AudioSource source;
    public GameObject button;
    public Sprite oldsprite;
    public Sprite newsprite;
    // Use this for initialization
    void Start () {
        musicOn = true;
        source = GetComponent<AudioSource>();
        source.PlayOneShot(bgSound, 0.1f);
    }
	
	// Update is called once per frame
	void Update () {
    }

    public void changeMusic()
    {
        Debug.Log("called");
        musicOn = !musicOn;
        if (!musicOn)
        {
            button.GetComponent<Image>().sprite = newsprite;
            source.Pause();
        }
        else
        {
            button.GetComponent<Image>().sprite = oldsprite;
            source.UnPause();
        }

    }
}
