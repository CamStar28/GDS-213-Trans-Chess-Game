using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class enemyRookScript : MonoBehaviour
{
    public Renderer rookRenderer;

    //public float rookScrollSpeed;
    //public GameObject speedController;

    public Rigidbody rookBody;

    public GameObject intervalLink;
    public float intervalTimer;
    
    public bool canMove;
    public bool isMovingRight;
    public bool hasBeenCaptured; 

    public float moveSpeed = 5f;
    public Transform movePoint;

    public GameObject leftCheck;
    public GameObject rightCheck;

    // Start is called before the first frame update
    void Start()
    {
        //rookScrollSpeed = speedController.GetComponent<scrollSpeedController>().scrollSpeed;
        
        intervalLink = GameObject.FindGameObjectWithTag("Player");

        intervalTimer = intervalLink.GetComponent<playerController>().intervalTime;
        
        canMove = false;
        isMovingRight = true; 
        hasBeenCaptured = false;

        movePoint.parent = null;

        if (transform.position.x >= 0.55)
        {
            isMovingRight = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //rookBody.velocity = new Vector3(0, 0, rookScrollSpeed);

        intervalTimer += Time.deltaTime; 
        if(intervalTimer >= 1.19f && intervalTimer < 1.2f)
        {
            canMove = true;  
        } else if (intervalTimer >= 1.2f)
        {
            canMove = false;
            intervalTimer = 0; 
        }

        if(leftCheck.GetComponent<pieceTileCheck>().tileOccupied == true)
        {
            isMovingRight = true;
        }
        
        if (rightCheck.GetComponent<pieceTileCheck>().tileOccupied == true)
        {
            isMovingRight = false;
        }

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) == 0f && canMove == true && hasBeenCaptured == false)
        {
            if(isMovingRight == true)
            {
                movePoint.position += new Vector3(1f, 0f, 0f);
            } else
            {
                movePoint.position += new Vector3(-1f, 0f, 0f);
            }

            canMove = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.GetComponent<playerController>().canCapture == true)
            {
                other.gameObject.GetComponent<playerController>().rookPowerUps += 1;
                StartCoroutine(Fade());
                hasBeenCaptured = true;
                Debug.Log("absolutely rooked upon");
            }
            else
            {
                StartCoroutine(other.gameObject.GetComponent<playerController>().TakeDamage());
                Destroy(gameObject);
            }
        }
        else if (other.gameObject.layer == 6)
        {
            StartCoroutine(Fade());
        }
    }

    IEnumerator Fade()
    {
        hasBeenCaptured = true;
        
        Color c = rookRenderer.material.color;
        for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
        {
            c.a = alpha;
            rookRenderer.material.color = c;
            yield return new WaitForSeconds(0.01f);
        }

        Destroy(gameObject);
    }
}
