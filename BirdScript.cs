using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float FlapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (logic.gameStarted){

            if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive){
                myRigidBody.linearVelocity = new Vector2(0f, FlapStrength);
            }

        } else {
            myRigidBody.linearVelocity = new Vector3(0, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }

}
