using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pieceTileCheck : MonoBehaviour
{
    public bool tileOccupied; 

    // Start is called before the first frame update
    void Start()
    {
        tileOccupied = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player") && other.gameObject.layer != 7)
        {
            tileOccupied = true; 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        tileOccupied = false; 
    }
}
