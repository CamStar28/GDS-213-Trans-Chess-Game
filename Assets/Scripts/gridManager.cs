using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridManager : MonoBehaviour
{
    
    public int gridWidth, gridHeight;

    public GameObject tilePrefab; 
    
    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateGrid()
    {
        for (int x = 0; x < gridWidth; x++)
        {
            for (int z = 0; z < gridHeight; z++)
            {
                var spawnedTile = Instantiate(tilePrefab, new Vector3(x - 6.45f, -0.18f, z - 3.45f), Quaternion.identity);

                var isOffset = (x % 2 == 0 &&  z % 2 != 0) || (x % 2 != 0 && z % 2 == 0);
                spawnedTile.GetComponent<tileScript>().ChangeColour(isOffset);
            }
        }
    }
}
