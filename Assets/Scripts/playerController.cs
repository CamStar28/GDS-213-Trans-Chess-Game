using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    public float speedReduction;
    public GameObject speedController;
    
    public Rigidbody playerBody; 
    public bool gameIsPaused; 

    public bool isJumping;
    
    // Start is called before the first frame update
    void Start()
    {
        speedReduction = speedController.GetComponent<scrollSpeedController>().scrollSpeed; 
        
        gameIsPaused = false;
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameIsPaused == false)
        {
            
            playerBody.velocity = new Vector3(0, 0, speedReduction);
            
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                playerBody.velocity = new Vector3(0, 0, 5 + speedReduction * 2);
            }

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                playerBody.velocity = new Vector3(5, 0, 0 + speedReduction);
            }

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                playerBody.velocity = new Vector3(-5, 0, 0 + speedReduction);
            }

            if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
            {
                playerBody.velocity = new Vector3(5, 0, 5 + speedReduction * 2);
            }

            if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
            {
                playerBody.velocity = new Vector3(-5, 0, 5 + speedReduction * 2);
            }

            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                playerBody.velocity = new Vector3(0, 0, -5 + speedReduction);
            }

            if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
            {
                playerBody.velocity = new Vector3(5, 0, -5 + speedReduction);
            }

            if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
            {
                playerBody.velocity = new Vector3(-5, 0, -5 + speedReduction);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused == false)
            {
                Time.timeScale = 0;
                gameIsPaused = true;
            }
            else
            {
                Time.timeScale = 1;
                gameIsPaused = false;
            }
        }
    }
}
