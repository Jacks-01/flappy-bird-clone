using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody2D;

    public float flapStrength;

    public LogicManager logic;

    public bool birdIsAlive = true;

    public float topBounds = 15f;

    public float bottomBounds = -15;

    // Start is called before the first frame update
    void Start()
    {
        logic =
            GameObject
                .FindGameObjectWithTag("Logic")
                .GetComponent<LogicManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive == true)
        {
            myRigidbody2D.velocity = Vector2.up * flapStrength;
            // Debug.Log(myRigidbody2D.position.y);
        }

        if (myRigidbody2D.position.y <= bottomBounds)
        {
            logic.gameOver();
            birdIsAlive = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }
}
