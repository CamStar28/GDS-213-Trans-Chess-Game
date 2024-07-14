using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

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

    //public LayerMask enemyPiecesLayer;
    //pretty sure this is no longer needed, but keeping it here just in case. Remember to delete later CAM 


    public GameObject upLeftCheck;
    public GameObject upRightCheck;
    public GameObject upCheck;
    public GameObject leftCheck;
    public GameObject rightCheck;

    public int pawnPowerUps;
    public TextMeshProUGUI pawnPowerUpUI;
    public int knightPowerUps;
    public TextMeshProUGUI knightPowerUpUI;
    public int bishopPowerUps;
    public TextMeshProUGUI bishopPowerUpUI;
    public int rookPowerUps;
    public TextMeshProUGUI rookPowerUpUI;
    
    public TextMeshProUGUI powerUpArrow;
    public int arrowPosition;

    public SpriteRenderer playerRenderer;
    public Sprite pawnSprite;
    public Sprite knightSprite;
    public Sprite bishopSprite;
    public Sprite rookSprite;

    public int playerPiece;

    public GameObject doubleUpCheck;

    public GameObject farRightCheck; 
    public GameObject farLeftCheck;
    public GameObject topRightCheck; 
    public GameObject topLeftCheck;

    public GameObject bishopLeftCheck; 
    public GameObject bishopRightCheck;

    public GameObject rookLeftCheck;
    public GameObject rookRightCheck;


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

        pawnPowerUps = 0;
        knightPowerUps = 0;
        bishopPowerUps = 0;
        rookPowerUps = 0;

        arrowPosition = 0;
    }

    // Update is called once per frame
    void Update()
    {

        pawnPowerUpUI.text = "-  " + pawnPowerUps;
        knightPowerUpUI.text = "-  " + knightPowerUps;
        bishopPowerUpUI.text = "-  " + bishopPowerUps;
        rookPowerUpUI.text = "-  " + rookPowerUps;


        if (gameIsPaused == false)
        {
            intervalTime += Time.deltaTime;
            intervalBar += Time.deltaTime;

            intervalIndicator.value = intervalBar;

            if(intervalTime >= 0.8f && intervalTime < 0.801f)
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
                if(playerPiece == 0)
                {
                    if (Input.GetKeyDown(KeyCode.D) && rightCheck.GetComponent<pawnTileCheck>().tileHasPiece == false && rightCheck.GetComponent<pawnTileCheck>().tileHasWall == false)
                    {
                        movePoint.position += new Vector3(1f, 0f, 0f);
                        canMove = false;
                        //Debug.Log(movePoint.position);

                    }
                    else if (Input.GetKeyDown(KeyCode.A) && leftCheck.GetComponent<pawnTileCheck>().tileHasPiece == false && leftCheck.GetComponent<pawnTileCheck>().tileHasWall == false)
                    {
                        movePoint.position += new Vector3(-1f, 0f, 0f);
                        canMove = false;
                        //Debug.Log(movePoint.position);

                    }
                    else if (Input.GetKeyDown(KeyCode.W) && upCheck.GetComponent<pawnTileCheck>().tileHasPiece == false && upCheck.GetComponent<pawnTileCheck>().tileHasWall == false)
                    {
                        movePoint.position += new Vector3(0f, 0f, 1f);
                        canMove = false;
                        //Debug.Log(movePoint.position);
                    }
                    else if (Input.GetKey(KeyCode.E) && upRightCheck.GetComponent<pawnTileCheck>().tileHasPiece == true && upRightCheck.GetComponent<pawnTileCheck>().tileHasWall == false)
                    {
                        movePoint.position += new Vector3(1f, 0f, 1f);
                        canMove = false;
                    }
                    else if (Input.GetKey(KeyCode.Q) && upLeftCheck.GetComponent<pawnTileCheck>().tileHasPiece == true && upLeftCheck.GetComponent<pawnTileCheck>().tileHasWall == false)
                    {
                        movePoint.position += new Vector3(-1f, 0f, 1f);
                        canMove = false;
                    }
                } else if(playerPiece == 1)
                {
                    if (Input.GetKeyDown(KeyCode.D) && rightCheck.GetComponent<pawnTileCheck>().tileHasPiece == false && rightCheck.GetComponent<pawnTileCheck>().tileHasWall == false)
                    {
                        movePoint.position += new Vector3(1f, 0f, 0f);
                        canMove = false;
                        //Debug.Log(movePoint.position);

                    }
                    else if (Input.GetKeyDown(KeyCode.A) && leftCheck.GetComponent<pawnTileCheck>().tileHasPiece == false && leftCheck.GetComponent<pawnTileCheck>().tileHasWall == false)
                    {
                        movePoint.position += new Vector3(-1f, 0f, 0f);
                        canMove = false;
                        //Debug.Log(movePoint.position);

                    }
                    else if (Input.GetKeyDown(KeyCode.W) && upCheck.GetComponent<pawnTileCheck>().tileHasPiece == false && upCheck.GetComponent<pawnTileCheck>().tileHasWall == false && doubleUpCheck.GetComponent<pawnTileCheck>().tileHasPiece == false && doubleUpCheck.GetComponent<pawnTileCheck>().tileHasWall == false)
                    {
                        movePoint.position += new Vector3(0f, 0f, 2f);
                        canMove = false;
                        //Debug.Log(movePoint.position);
                        playerPiece = 0;
                        //playerRenderer.sprite = pawnSprite;
                        StartCoroutine(speedResetCooldown(1f));
                    }
                    else if (Input.GetKey(KeyCode.E) && upRightCheck.GetComponent<pawnTileCheck>().tileHasPiece == true && upRightCheck.GetComponent<pawnTileCheck>().tileHasWall == false)
                    {
                        movePoint.position += new Vector3(1f, 0f, 1f);
                        canMove = false;
                    }
                    else if (Input.GetKey(KeyCode.Q) && upLeftCheck.GetComponent<pawnTileCheck>().tileHasPiece == true && upLeftCheck.GetComponent<pawnTileCheck>().tileHasWall == false)
                    {
                        movePoint.position += new Vector3(-1f, 0f, 1f);
                        canMove = false;
                    }
                } else if(playerPiece == 2)
                {
                    if (Input.GetKeyDown(KeyCode.D) && farRightCheck.GetComponent<pawnTileCheck>().tileHasWall == false)
                    {
                        movePoint.position += new Vector3(2f, 0f, 1f);
                        canMove = false;
                        //Debug.Log(movePoint.position);
                        playerPiece = 0;
                        //playerRenderer.sprite = pawnSprite;
                        StartCoroutine(speedResetCooldown(1f));
                        StartCoroutine(spriteReset(0.25f));

                    }
                    else if (Input.GetKeyDown(KeyCode.A) && farLeftCheck.GetComponent<pawnTileCheck>().tileHasWall == false)
                    {
                        movePoint.position += new Vector3(-2f, 0f, 1f);
                        canMove = false;
                        //Debug.Log(movePoint.position);
                        playerPiece = 0;
                        //playerRenderer.sprite = pawnSprite;
                        StartCoroutine(speedResetCooldown(1f));
                        StartCoroutine(spriteReset(0.25f));

                    }
                    else if (Input.GetKey(KeyCode.E) && topRightCheck.GetComponent<pawnTileCheck>().tileHasWall == false)
                    {
                        movePoint.position += new Vector3(1f, 0f, 2f);
                        canMove = false;
                        playerPiece = 0;
                        //playerRenderer.sprite = pawnSprite;
                        StartCoroutine(speedResetCooldown(1f));
                        StartCoroutine(spriteReset(0.25f));
                    }
                    else if (Input.GetKey(KeyCode.Q) && topLeftCheck.GetComponent<pawnTileCheck>().tileHasWall == false)
                    {
                        movePoint.position += new Vector3(-1f, 0f, 2f);
                        canMove = false;
                        playerPiece = 0;
                        //playerRenderer.sprite = pawnSprite;
                        StartCoroutine(speedResetCooldown(1f));
                        StartCoroutine(spriteReset(0.25f));
                    }
                } else if(playerPiece == 3)
                {
                    if (Input.GetKey(KeyCode.E) && upRightCheck.GetComponent<pawnTileCheck>().tileHasWall == false && bishopRightCheck.GetComponent<pawnTileCheck>().tileHasWall == false)
                    {
                        movePoint.position += new Vector3(2f, 0f, 2f);
                        canMove = false;
                        playerPiece = 0;
                        //playerRenderer.sprite = pawnSprite;
                        StartCoroutine(speedResetCooldown(1f));
                        StartCoroutine(spriteReset(0.25f));
                    }
                    else if (Input.GetKey(KeyCode.Q) && upRightCheck.GetComponent<pawnTileCheck>().tileHasWall == false && bishopRightCheck.GetComponent<pawnTileCheck>().tileHasWall == false)
                    {
                        movePoint.position += new Vector3(-2f, 0f, 2f);
                        canMove = false;
                        playerPiece = 0;
                        //playerRenderer.sprite = pawnSprite;
                        StartCoroutine(speedResetCooldown(1f));
                        StartCoroutine(spriteReset(0.25f));
                    }
                } else if(playerPiece == 4)
                {
                    if (Input.GetKeyDown(KeyCode.D) && rightCheck.GetComponent<pawnTileCheck>().tileHasWall == false && rookRightCheck.GetComponent<pawnTileCheck>().tileHasWall == false)
                    {
                        movePoint.position += new Vector3(2f, 0f, 0f);
                        canMove = false;
                        //Debug.Log(movePoint.position);
                        playerPiece = 0;
                        //playerRenderer.sprite = pawnSprite;
                        StartCoroutine(speedResetCooldown(1f));
                        StartCoroutine(spriteReset(0.25f));

                    }
                    else if (Input.GetKeyDown(KeyCode.A) && leftCheck.GetComponent<pawnTileCheck>().tileHasWall == false && rookLeftCheck.GetComponent<pawnTileCheck>().tileHasWall == false)
                    {
                        movePoint.position += new Vector3(-2f, 0f, 0f);
                        canMove = false;
                        //Debug.Log(movePoint.position);
                        playerPiece = 0;
                        //playerRenderer.sprite = pawnSprite;
                        StartCoroutine(speedResetCooldown(1f));
                        StartCoroutine(spriteReset(0.25f));

                    }
                    else if (Input.GetKeyDown(KeyCode.W) && upCheck.GetComponent<pawnTileCheck>().tileHasWall == false && doubleUpCheck.GetComponent<pawnTileCheck>().tileHasWall == false)
                    {
                        movePoint.position += new Vector3(0f, 0f, 2f);
                        canMove = false;
                        //Debug.Log(movePoint.position);
                        playerPiece = 0;
                        //playerRenderer.sprite = pawnSprite;
                        StartCoroutine(speedResetCooldown(1f));
                        StartCoroutine(spriteReset(0.25f));
                    }
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (arrowPosition == 3)
            {
                arrowPosition = 0;
            }
            else
            {
                arrowPosition += 1;
            }
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(arrowPosition == 0)
            {
                if(pawnPowerUps > 0)
                {
                    Debug.Log("become pawn");
                    playerPiece = 1; 
                    pawnPowerUps -= 1;
                    playerRenderer.sprite = pawnSprite;
                } else
                {
                    Debug.Log("got no pawns girl"); 
                }
            }

            if (arrowPosition == 1)
            {
                if (knightPowerUps > 0)
                {
                    Debug.Log("become knight");
                    playerPiece = 2;
                    knightPowerUps -= 1;
                    playerRenderer.sprite = knightSprite;
                    moveSpeed = 10f;
                }
                else
                {
                    Debug.Log("got no knights girl");
                }
            }

            if (arrowPosition == 2)
            {
                if (bishopPowerUps > 0)
                {
                    Debug.Log("become bishop");
                    playerPiece = 3;
                    bishopPowerUps -= 1;
                    playerRenderer.sprite = bishopSprite;
                    moveSpeed = 10f;
                }
                else
                {
                    Debug.Log("got no bishops girl");
                }
            }

            if (arrowPosition == 3)
            {
                if (rookPowerUps > 0)
                {
                    Debug.Log("become rook");
                    playerPiece = 4;
                    rookPowerUps -= 1;
                    playerRenderer.sprite = rookSprite;
                    moveSpeed = 10f;
                }
                else
                {
                    Debug.Log("got no rooks girl");
                }
            }
        }


        if(arrowPosition == 0)
        {
            powerUpArrow.rectTransform.anchoredPosition = new Vector2(-25, 153);
        } else if(arrowPosition == 1)
        {
            powerUpArrow.rectTransform.anchoredPosition = new Vector2(-25, 58); 
        } else if(arrowPosition == 2)
        {
            powerUpArrow.rectTransform.anchoredPosition = new Vector2(-25, -40);
        } else if(arrowPosition == 3)
        {
            powerUpArrow.rectTransform.anchoredPosition = new Vector2(-25, -140); 
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

    IEnumerator speedResetCooldown(float delay)
    {
        yield return new WaitForSeconds(delay);
        moveSpeed = 5f; 
    }

    IEnumerator spriteReset(float delay)
    {
        yield return new WaitForSeconds(delay);
        playerRenderer.sprite = pawnSprite; 
    }

}
