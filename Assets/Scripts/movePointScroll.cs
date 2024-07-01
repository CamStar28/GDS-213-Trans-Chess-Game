using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePointScroll : MonoBehaviour
{

    public Rigidbody pointBody;
    public float pointScrollSpeed;
    public GameObject speedController; 

    // Start is called before the first frame update
    void Start()
    {
        pointScrollSpeed = speedController.GetComponent<scrollSpeedController>().scrollSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        pointBody.velocity = new Vector3(0, 0, pointScrollSpeed);
    }
}
