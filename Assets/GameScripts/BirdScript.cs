using UnityEngine;

public class BirdScript : MonoBehaviour
{
    private Rigidbody2D RB;
    public Rigidbody2D myRigidbody;
    public GameScript game;
    public float FlapStrength;
    public bool birdIsAlive = true;
    public float velocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        game = GameObject.FindGameObjectWithTag("game").GetComponent<GameScript>();
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (birdIsAlive)
        {
            velocityToRotation();
        }
        if (Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive)
        {
            myRigidbody.linearVelocity = Vector2.up * FlapStrength;

        }
        if (transform.position.y <= -14 || transform.position.y >= 15)
        {
            GameOverState();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameOverState();
    }
    public void GameOverState()
    {
        game.gameOver();
        birdIsAlive = false;
    }

    public void velocityToRotation()
    {
        velocity = RB.linearVelocityY;
        myRigidbody.transform.rotation = Quaternion.AngleAxis(velocity, Vector3.forward);
    }
}
