using UnityEngine;

public class PointsUp : MonoBehaviour
{
    public GameScript game;
    public BirdScript bird;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        game = GameObject.FindGameObjectWithTag("game").GetComponent<GameScript>();
        bird = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //To ensure that bird collides with points trigger and not something else
        if (collision.gameObject.layer == 3 && bird.birdIsAlive)
        {
            game.addScore(1);
        }

    }
}
