using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pawnTileCheck : MonoBehaviour
{

    public GameObject playerPawn;
    public string triggerTag;

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
        if(other.gameObject.tag == "EnemyPawn")
        {
            //give Pawn power up
            tileHasPiece = true;
        }
    }
}
