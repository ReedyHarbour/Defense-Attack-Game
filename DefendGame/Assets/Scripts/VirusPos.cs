using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusPos : MonoBehaviour {
    public GameObject[] virus = new GameObject[3];
    public Transform canvas;
    public GameObject parentCell;
    public void generateVirus(int i)
    {
        Transform cell = Instantiate(virus[i].transform, transform.position, Quaternion.identity);
        cell.parent = parentCell.transform;
    }
}
