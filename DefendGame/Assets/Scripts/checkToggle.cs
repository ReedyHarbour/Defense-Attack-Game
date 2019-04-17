using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class checkToggle : MonoBehaviour {
    public Toggle m_Toggle;
    public static bool isOn = false;
    // Use this for initialization
    void Start () {
        isOn = m_Toggle.isOn;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ToggleValueChanged(Toggle change)
    {
        isOn = m_Toggle.isOn;
        print(isOn);
    }
}
