using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour {
    public Transform virus;

    public void generateVirus()
    {
        Transform cell = Instantiate(virus, transform.position, Quaternion.identity);
        if (!Board.cells.Contains(cell))
        {
            Board.cells.Add(cell);
        }
    }
}
