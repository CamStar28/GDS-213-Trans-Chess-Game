using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class playerController : MonoBehaviour
{

    //public float speedReduction;
    //public GameObject speedController;
    
    //public Rigidbody playerBody; 
    public bool gameIsPaused;

    public float moveSpeed = 5f;
    public Transform movePoint;

    public float intervalTime;
    public bool canMove;
    public Slider intervalIndicator;
    public float intervalBar;

    public LayerMask enemyPiecesLayer; 
    
    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null; 
        
        //speedReduction = speedController.GetComponent<scrollSpeedController>().scrollSpeed; 
        
        gameIsPaused = false;

        intervalTime = 0; 
        intervalBar = 0;
        intervalIndicator.maxValue = 0.8f; 
        canMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameIsPaused == false)
        {
            intervalTime += Time.deltaTime;
            intervalBar += Time.deltaTime;

            intervalIndicator.value = intervalBar;

            if(intervalTime >= 0.8f && intervalTime < 0.81f)
            {
                canMove = true; 
            } else if (intervalTime >= 1.2f)
            {
                canMove = false;
                intervalTime = 0;
                intervalBar = 0;
            }

            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
            
            if(Vector3.Distance(transform.position, movePoint.position) == 0f && canMove == true)
            {
                if (Input.GetKeyDown(KeyCode.D))
                {
                    movePoint.position += new Vector3(1f, 0f, 0f);
                    canMove = false;
                    //Debug.Log(movePoint.position);

                } else if (Input.GetKeyDown(KeyCode.A))
                {
                    movePoint.position += new Vector3(-1f, 0f, 0f);
                    canMove = false;
                    //Debug.Log(movePoint.position);

                } else if (Input.GetKeyDown(KeyCode.W))
                {
                    movePoint.position += new Vector3(0f, 0f, 1f);
                    canMove = false;
                    //Debug.Log(movePoint.position);
                } else if (Input.GetKey(KeyCode.E))
                {
                    movePoint.position += new Vector3(1f, 0f, 1f); 
                    canMove = false;
                } else if (Input.GetKey(KeyCode.Q))
                {
                    movePoint.position += new Vector3(-1f, 0f, 1f);
                    canMove = false;
                }
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



    //Physics.OverlapSphere(movePoint.position + new Vector3(1f, 0f, 1f), 0.2f, enemyPiecesLayer

}
