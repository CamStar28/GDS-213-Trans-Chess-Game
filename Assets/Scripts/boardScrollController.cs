using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boardScrollController : MonoBehaviour
{

    public float boardScrollSpeed;
    public GameObject speedController;

    public Rigidbody boardBody;

    // Start is called before the first frame update
    void Start()
    {
        boardScrollSpeed = speedController.GetComponent<scrollSpeedController>().scrollSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        boardBody.velocity = new Vector3(0, 0, boardScrollSpeed);
    }
}
