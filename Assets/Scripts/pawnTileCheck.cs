using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pawnTileCheck : MonoBehaviour
{
    
    public bool tileHasPiece;
    public bool tileHasWall; 
    
    // Start is called before the first frame update
    void Start()
    {
        tileHasPiece = false;
        tileHasWall = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6)
        {
            tileHasPiece = true;
        } else if(other.gameObject.tag == "Wall") 
        { 
            tileHasWall = true; 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        tileHasPiece = false;
        tileHasWall = false; 
    }

}
