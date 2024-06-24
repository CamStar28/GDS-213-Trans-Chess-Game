using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPawnController : MonoBehaviour
{
    public float pieceScrollSpeed;
    public GameObject speedController;

    public Rigidbody pieceBody;

    // Start is called before the first frame update
    void Start()
    {
        pieceScrollSpeed = speedController.GetComponent<scrollSpeedController>().scrollSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        pieceBody.velocity = new Vector3(0, 0, pieceScrollSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("what's pawnma");
            Destroy(gameObject);
        }
    }
}
