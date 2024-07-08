using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyKnightScript : MonoBehaviour
{
    public Renderer knightRenderer;

    //public float knightScrollSpeed;
    //public GameObject speedController;

    public Rigidbody knightBody;

    public GameObject intervalLink;
    public float intervalTimer;

    public bool canMove;
    public int movingToPosition;
    public bool hasBeenCaptured;

    public float moveSpeed = 5f;
    public Transform movePoint;

    public GameObject farLeftCheck;
    public GameObject bottomLeftCheck;
    public GameObject bottomRightCheck; 
    public GameObject farRightCheck;

    // Start is called before the first frame update
    void Start()
    {
        //knightScrollSpeed = speedController.GetComponent<scrollSpeedController>().scrollSpeed;

        intervalLink = GameObject.FindGameObjectWithTag("Player");

        intervalTimer = intervalLink.GetComponent<playerController>().intervalTime;

        canMove = false;
        movingToPosition = 0;
        hasBeenCaptured = false;

        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        //knightBody.velocity = new Vector3(0, 0, knightScrollSpeed);

        intervalTimer += Time.deltaTime;
        if (intervalTimer >= 1.19f && intervalTimer < 1.2f)
        {
            canMove = true;
        }
        else if (intervalTimer >= 1.2f)
        {
            canMove = false;
            intervalTimer = 0;
        }


        if (farRightCheck.GetComponent<pieceTileCheck>().tileOccupied == true && movingToPosition == 0)
        {
            movingToPosition += 1;
        }

        if (bottomRightCheck.GetComponent<pieceTileCheck>().tileOccupied == true && movingToPosition == 1)
        {
            movingToPosition += 1; 
        }

        if (bottomLeftCheck.GetComponent<pieceTileCheck>().tileOccupied == true && movingToPosition == 2)
        {
            movingToPosition += 1; 
        }

        if (farLeftCheck.GetComponent<pieceTileCheck>().tileOccupied == true && movingToPosition == 3)
        {
            movingToPosition = 0; 
        }



        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) == 0f && canMove == true && hasBeenCaptured == false)
        {
            if (movingToPosition == 0)
            {
                movePoint.position += new Vector3(2f, 0f, -1f);
                movingToPosition += 1;
            }
            else if (movingToPosition == 1)
            {
                movePoint.position += new Vector3(1f, 0f, -2f);
                movingToPosition += 1;
            }
            else if (movingToPosition == 2)
            {
                movePoint.position += new Vector3(-1f, 0f, -2f);
                movingToPosition += 1;
            }
            else if (movingToPosition == 3)
            {
                movePoint.position += new Vector3(-2f, 0f, -1f);
                movingToPosition += 1;
            }

            canMove = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<playerController>().knightPowerUps += 1;
            StartCoroutine(Fade());
            hasBeenCaptured = true;
            Debug.Log("absolutely knighted upon");
        }
    }

    IEnumerator Fade()
    {
        Color c = knightRenderer.material.color;
        for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
        {
            c.a = alpha;
            knightRenderer.material.color = c;
            yield return new WaitForSeconds(0.01f);
        }

        Destroy(gameObject);
    }
}
