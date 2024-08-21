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
    public GameObject pauseMenu; 

    public float moveSpeed = 5f;
    public Transform movePoint;

    public float intervalTime;
    public bool canMove;
    public Slider intervalIndicator;
    public Slider damagedInterval;
    public GameObject intervalObject;
    public GameObject damagedIntervalObject;
    public float intervalBar;

    public bool isStunned;

    //public LayerMask enemyPiecesLayer;
    //pretty sure this is no longer needed, but keeping it here just in case. Remember to delete later CAM 


    public GameObject upLeftCheck;
    public GameObject upRightCheck;
    public GameObject upCheck;
    public GameObject leftCheck;
    public GameObject rightCheck;

    public bool canCapture; 

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
    public Sprite queenSprite; 

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

    public AudioSource pieceMove;
    public AudioSource copyUseSound;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(-2.41f, 0, -2.48f);
        movePoint.transform.position = transform.position;
        
        movePoint.parent = null; 
        
        //speedReduction = speedController.GetComponent<scrollSpeedController>().scrollSpeed; 
        
        gameIsPaused = false;
        Time.timeScale = 0; 
        StartCoroutine(UnpauseGameStart());

        intervalTime = 0; 
        intervalBar = 0;
        intervalIndicator.maxValue = 0.8f;
        damagedInterval.maxValue = 0.8f;
        canMove = false;
        isStunned = false;

        pawnPowerUps = 1;
        knightPowerUps = 0;
        bishopPowerUps = 0;
        rookPowerUps = 0;

        arrowPosition = 0;

        StartCoroutine(IntervalSystem());
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
            damagedInterval.value = intervalBar;

            if(isStunned == true)
            {
                intervalObject.SetActive(false);
                damagedIntervalObject.SetActive(true);
            } else
            {
                intervalObject.SetActive(true);
                damagedIntervalObject.SetActive(false);
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
                        pieceMove.Play(0);

                    }
                    else if (Input.GetKeyDown(KeyCode.A) && leftCheck.GetComponent<pawnTileCheck>().tileHasPiece == false && leftCheck.GetComponent<pawnTileCheck>().tileHasWall == false)
                    {
                        movePoint.position += new Vector3(-1f, 0f, 0f);
                        canMove = false;
                        //Debug.Log(movePoint.position);
                        pieceMove.Play(0);

                    }
                    else if (Input.GetKeyDown(KeyCode.W) && upCheck.GetComponent<pawnTileCheck>().tileHasPiece == false && upCheck.GetComponent<pawnTileCheck>().tileHasWall == false)
                    {
                        movePoint.position += new Vector3(0f, 0f, 1f);
                        canMove = false;
                        //Debug.Log(movePoint.position);
                        pieceMove.Play(0);
                    }
                    else if (Input.GetKey(KeyCode.E) && upRightCheck.GetComponent<pawnTileCheck>().tileHasPiece == true && upRightCheck.GetComponent<pawnTileCheck>().tileHasWall == false)
                    {
                        movePoint.position += new Vector3(1f, 0f, 1f);
                        canMove = false;
                        pieceMove.Play(0);
                        StartCoroutine(CaptureState());
                    }
                    else if (Input.GetKey(KeyCode.Q) && upLeftCheck.GetComponent<pawnTileCheck>().tileHasPiece == true && upLeftCheck.GetComponent<pawnTileCheck>().tileHasWall == false)
                    {
                        movePoint.position += new Vector3(-1f, 0f, 1f);
                        canMove = false;
                        pieceMove.Play(0);
                        StartCoroutine(CaptureState());
                    }
                } else if(playerPiece == 1)
                {
                    if (Input.GetKeyDown(KeyCode.D) && rightCheck.GetComponent<pawnTileCheck>().tileHasPiece == false && rightCheck.GetComponent<pawnTileCheck>().tileHasWall == false)
                    {
                        movePoint.position += new Vector3(1f, 0f, 0f);
                        canMove = false;
                        //Debug.Log(movePoint.position);
                        pieceMove.Play(0);

                    }
                    else if (Input.GetKeyDown(KeyCode.A) && leftCheck.GetComponent<pawnTileCheck>().tileHasPiece == false && leftCheck.GetComponent<pawnTileCheck>().tileHasWall == false)
                    {
                        movePoint.position += new Vector3(-1f, 0f, 0f);
                        canMove = false;
                        //Debug.Log(movePoint.position);
                        pieceMove.Play(0);

                    }
                    else if (Input.GetKeyDown(KeyCode.W) && upCheck.GetComponent<pawnTileCheck>().tileHasPiece == false && upCheck.GetComponent<pawnTileCheck>().tileHasWall == false && doubleUpCheck.GetComponent<pawnTileCheck>().tileHasPiece == false && doubleUpCheck.GetComponent<pawnTileCheck>().tileHasWall == false)
                    {
                        movePoint.position += new Vector3(0f, 0f, 2f);
                        canMove = false;
                        //Debug.Log(movePoint.position);
                        playerPiece = 0;
                        //playerRenderer.sprite = pawnSprite;
                        pieceMove.Play(0);
                        StartCoroutine(speedResetCooldown(1f));
                    }
                    else if (Input.GetKey(KeyCode.E) && upRightCheck.GetComponent<pawnTileCheck>().tileHasPiece == true && upRightCheck.GetComponent<pawnTileCheck>().tileHasWall == false)
                    {
                        movePoint.position += new Vector3(1f, 0f, 1f);
                        canMove = false;
                        pieceMove.Play(0);
                    }
                    else if (Input.GetKey(KeyCode.Q) && upLeftCheck.GetComponent<pawnTileCheck>().tileHasPiece == true && upLeftCheck.GetComponent<pawnTileCheck>().tileHasWall == false)
                    {
                        movePoint.position += new Vector3(-1f, 0f, 1f);
                        canMove = false;
                        pieceMove.Play(0);
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
                        pieceMove.Play(0);
                        StartCoroutine(speedResetCooldown(1f));
                        StartCoroutine(spriteReset(0.25f));
                        StartCoroutine(CaptureState());

                    }
                    else if (Input.GetKeyDown(KeyCode.A) && farLeftCheck.GetComponent<pawnTileCheck>().tileHasWall == false)
                    {
                        movePoint.position += new Vector3(-2f, 0f, 1f);
                        canMove = false;
                        //Debug.Log(movePoint.position);
                        playerPiece = 0;
                        //playerRenderer.sprite = pawnSprite;
                        pieceMove.Play(0);
                        StartCoroutine(speedResetCooldown(1f));
                        StartCoroutine(spriteReset(0.25f));
                        StartCoroutine(CaptureState());

                    }
                    else if (Input.GetKey(KeyCode.E) && topRightCheck.GetComponent<pawnTileCheck>().tileHasWall == false)
                    {
                        movePoint.position += new Vector3(1f, 0f, 2f);
                        canMove = false;
                        playerPiece = 0;
                        //playerRenderer.sprite = pawnSprite;
                        pieceMove.Play(0);
                        StartCoroutine(speedResetCooldown(1f));
                        StartCoroutine(spriteReset(0.25f));
                        StartCoroutine(CaptureState());
                    }
                    else if (Input.GetKey(KeyCode.Q) && topLeftCheck.GetComponent<pawnTileCheck>().tileHasWall == false)
                    {
                        movePoint.position += new Vector3(-1f, 0f, 2f);
                        canMove = false;
                        playerPiece = 0;
                        //playerRenderer.sprite = pawnSprite;
                        pieceMove.Play(0);
                        StartCoroutine(speedResetCooldown(1f));
                        StartCoroutine(spriteReset(0.25f));
                        StartCoroutine(CaptureState());
                    }
                } else if(playerPiece == 3)
                {
                    if (Input.GetKey(KeyCode.E) && upRightCheck.GetComponent<pawnTileCheck>().tileHasWall == false && bishopRightCheck.GetComponent<pawnTileCheck>().tileHasWall == false)
                    {
                        movePoint.position += new Vector3(2f, 0f, 2f);
                        canMove = false;
                        playerPiece = 0;
                        //playerRenderer.sprite = pawnSprite;
                        pieceMove.Play(0);
                        StartCoroutine(speedResetCooldown(1f));
                        StartCoroutine(spriteReset(0.25f));
                        StartCoroutine(CaptureState());
                    }
                    else if (Input.GetKey(KeyCode.Q) && upRightCheck.GetComponent<pawnTileCheck>().tileHasWall == false && bishopRightCheck.GetComponent<pawnTileCheck>().tileHasWall == false)
                    {
                        movePoint.position += new Vector3(-2f, 0f, 2f);
                        canMove = false;
                        playerPiece = 0;
                        //playerRenderer.sprite = pawnSprite;
                        pieceMove.Play(0);
                        StartCoroutine(speedResetCooldown(1f));
                        StartCoroutine(spriteReset(0.25f));
                        StartCoroutine(CaptureState());
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
                        pieceMove.Play(0);
                        StartCoroutine(speedResetCooldown(1f));
                        StartCoroutine(spriteReset(0.25f));
                        StartCoroutine(CaptureState());

                    }
                    else if (Input.GetKeyDown(KeyCode.A) && leftCheck.GetComponent<pawnTileCheck>().tileHasWall == false && rookLeftCheck.GetComponent<pawnTileCheck>().tileHasWall == false)
                    {
                        movePoint.position += new Vector3(-2f, 0f, 0f);
                        canMove = false;
                        //Debug.Log(movePoint.position);
                        playerPiece = 0;
                        //playerRenderer.sprite = pawnSprite;
                        pieceMove.Play(0);
                        StartCoroutine(speedResetCooldown(1f));
                        StartCoroutine(spriteReset(0.25f));
                        StartCoroutine(CaptureState());

                    }
                    else if (Input.GetKeyDown(KeyCode.W) && upCheck.GetComponent<pawnTileCheck>().tileHasWall == false && doubleUpCheck.GetComponent<pawnTileCheck>().tileHasWall == false)
                    {
                        movePoint.position += new Vector3(0f, 0f, 2f);
                        canMove = false;
                        //Debug.Log(movePoint.position);
                        playerPiece = 0;
                        //playerRenderer.sprite = pawnSprite;
                        pieceMove.Play(0);
                        StartCoroutine(speedResetCooldown(1f));
                        StartCoroutine(spriteReset(0.25f));
                        StartCoroutine(CaptureState());
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
                    copyUseSound.Play();
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
                    copyUseSound.Play();
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
                    copyUseSound.Play();
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
                    copyUseSound.Play();
                }
                else
                {
                    Debug.Log("got no rooks girl");
                }
            }
        }


        if(arrowPosition == 0)
        {
            powerUpArrow.rectTransform.anchoredPosition = new Vector2(-33, 153);
        } else if(arrowPosition == 1)
        {
            powerUpArrow.rectTransform.anchoredPosition = new Vector2(-33, 58); 
        } else if(arrowPosition == 2)
        {
            powerUpArrow.rectTransform.anchoredPosition = new Vector2(-33, -40);
        } else if(arrowPosition == 3)
        {
            powerUpArrow.rectTransform.anchoredPosition = new Vector2(-33, -140); 
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused == false && Time.timeScale == 1)
            {
                Time.timeScale = 0;
                gameIsPaused = true;
                StartCoroutine(pauseMenu.GetComponent<pauseMenuScript>().OpenPauseMenu()); 
            }
        }
    }

    IEnumerator IntervalSystem()
    {
        yield return new WaitForSeconds(0.8f);
        
        if (isStunned == false)
        {
            canMove = true;
            //Debug.Log(canMove);
        }

        yield return new WaitForSeconds(0.4f);
        canMove = false;
        intervalBar = 0;
        intervalTime = 0;
        StartCoroutine(IntervalSystem());
    }
    
    IEnumerator CaptureState()
    {
        canCapture = true;
        yield return new WaitForSeconds(1); 
        canCapture = false;
    }

    public IEnumerator TakeDamage()
    {
        Debug.Log("took-a da damage");
        isStunned = true; 
        yield return new WaitForSeconds(1);
        isStunned = false;
    }

    public void GotHit()
    {
        StartCoroutine(TakeDamage());
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

    IEnumerator UnpauseGameStart()
    {
        yield return new WaitForSecondsRealtime(1);
        Time.timeScale = 1; 
    }

    public void PromoteToQueen()
    {
        playerRenderer.sprite = queenSprite;
    }

}
