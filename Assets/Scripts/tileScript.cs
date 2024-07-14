using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileScript : MonoBehaviour
{

    public Color baseColour;
    public Color offsetColour;

    public MeshRenderer tileRenderer;

    public float tileScrollSpeed;
    public GameObject speedController;

    public Rigidbody tileBody; 

    // Start is called before the first frame update
    void Start()
    {
        speedController = GameObject.FindGameObjectWithTag("Speed");

        tileScrollSpeed = speedController.GetComponent<scrollSpeedController>().scrollSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        tileBody.velocity = new Vector3(0, 0, tileScrollSpeed);
    }

    public void ChangeColour(bool isOffset)
    {
        if(isOffset == true)
        {
            tileRenderer.material.color = offsetColour;
        } else
        {
            tileRenderer.material.color = baseColour;
        }
    }
}
