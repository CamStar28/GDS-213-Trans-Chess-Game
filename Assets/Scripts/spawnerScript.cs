using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerScript : MonoBehaviour
{

    public GameObject pawnPrefab;
    public GameObject knightPrefab;
    public GameObject bishopPrefab;
    public GameObject rookPrefab;
    public GameObject wallPrefab;
    public float[] xPositions; 

    public float levelTime; 
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObject());
    }

    // Update is called once per frame
    void Update()
    {
        levelTime += Time.deltaTime; 
    }

    IEnumerator SpawnObject()
    {

        int objectToSpawn;
        int prefabPosition;

        for(int p = 0; p <= 89; p +=1)
        {
            objectToSpawn = Random.Range(0, 5);
            prefabPosition = Random.Range(0, xPositions.Length);

            if (objectToSpawn == 0)
            {
                Instantiate(pawnPrefab, new Vector3(xPositions[prefabPosition] + 0.03f, 0, 6.5f + p), Quaternion.Euler(new Vector3(-90, 0, -180)));
            }
            else if (objectToSpawn == 1)
            {
                Instantiate(knightPrefab, new Vector3(xPositions[prefabPosition], 0, 6.55f + p), Quaternion.Euler(new Vector3(-90, 0, -180)));
            }
            else if (objectToSpawn == 2)
            {
                Instantiate(bishopPrefab, new Vector3(xPositions[prefabPosition] + 0.03f, 0, 6.55f + p), Quaternion.Euler(new Vector3(-90, 0, -180)));
            }
            else if (objectToSpawn == 3)
            {
                Instantiate(rookPrefab, new Vector3(xPositions[prefabPosition] + 0.03f, 0, 6.5f + p), Quaternion.Euler(new Vector3(-90, 0, -180)));
            }
            else if (objectToSpawn == 4)
            {
                Instantiate(wallPrefab, new Vector3(xPositions[prefabPosition], 0, 6.55f + p), Quaternion.Euler(new Vector3(-90, 0, -180)));
            }

            yield return null;
        }
    }
}
