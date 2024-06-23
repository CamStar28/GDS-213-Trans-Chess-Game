using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    public Rigidbody playerBody; 
    public bool gameIsPaused; 
    
    // Start is called before the first frame update
    void Start()
    {
        gameIsPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameIsPaused == false)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                playerBody.velocity = new Vector3(0, 0, 5);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                playerBody.velocity = new Vector3(5, 0, 0);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                playerBody.velocity = new Vector3(-5, 0, 0);
            }

            if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow))
            {
                playerBody.velocity = new Vector3(5, 0, 5);
            }

            if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow))
            {
                playerBody.velocity = new Vector3(-5, 0, 5);
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                playerBody.velocity = new Vector3(0, 0, -5);
            }

            if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow))
            {
                playerBody.velocity = new Vector3(5, 0, -5);
            }

            if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow))
            {
                playerBody.velocity = new Vector3(-5, 0, -5);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                
            }
        }
    }
}
