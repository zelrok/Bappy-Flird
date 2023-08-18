using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    // public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public AudioSource flapSFX;

    // Start is called before the first frame update
    void Start()
    {
        // gameObject.name = "Birdy Birdy";
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (birdIsAlive)
        {
            // transform.Rotate(new Vector3(0, 0, 90));
            // myRigidbody.velocity = Vector2.up * 10;
            if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
            {
                flapSFX.Play();
                gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * flapStrength;
            }

            // new sweet spin moves
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                gameObject.GetComponent<Rigidbody2D>().rotation += 1;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                gameObject.GetComponent<Rigidbody2D>().rotation -= 1;
            }

            // did bird go off screen? its dead now
            if (transform.position.y > 12 || transform.position.y < -11.5)
            {
                birdIsAlive = false;
                logic.gameOver();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        birdIsAlive = false;
        logic.gameOver();
    }
}
