using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float FlapStrength;
    public GameScript game;
    public bool birdIsAlive = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        game = GameObject.FindGameObjectWithTag("game").GetComponent<GameScript>();
    }

    // Update is called once per frame
    void Update()
    {
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
}
