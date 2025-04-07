using UnityEngine;

public class PipeSpawn : MonoBehaviour
{
    [Header("Pipe Settings")]
    public GameObject pipe;
    public float spawnRate = 5f;
    private float spawnTimer = 0f;
    public float heightOffset = 10f;

    [Header("Difficulty Settings")]
    public PipeScript moveSpeed;
    public int difficultyLevel = 0;
    public float difficultyTimer = 0f;
    public float difficultyRate = 40f;
    public int difficultyCap = 8;

    [Header("Pause Timer")]
    public float waitTimer = 0f;
    public float waitTimerCutoff = 10f;
    private bool isPaused = false;

    void Start()
    {
        moveSpeed.moveSpeed = 5f;
        SpawnPipe();
        Debug.Log($"Initial Difficulty Rate: {difficultyRate}");
    }

    void Update()
    {
        if (isPaused)
        {
            HandlePauseTimer();
            return;
        }

        HandleDifficultyTimer();
        HandleSpawnTimer();
    }

    private void HandlePauseTimer()
    {
        waitTimer += Time.deltaTime;
        if (waitTimer >= waitTimerCutoff)
        {
            waitTimer = 0f;
            isPaused = false;
        }
    }

    private void HandleDifficultyTimer()
    {
        if (difficultyLevel < difficultyCap)
        {
            difficultyTimer += Time.deltaTime;
            if (difficultyTimer >= difficultyRate)
            {
                IncreaseDifficulty();
                difficultyTimer = 0f;
            }
        }
    }

    private void HandleSpawnTimer()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnRate)
        {
            SpawnPipe();
            spawnTimer = 0f;
        }
    }


    private void IncreaseDifficulty()
    {
        isPaused = true;
        difficultyLevel++;
        moveSpeed.moveSpeed += 2f;
        spawnRate = Mathf.Max(spawnRate - 0.5f, 0.5f);
        difficultyTimer = 0f;

        Debug.Log($"Difficulty Increased: Level {difficultyLevel}");
    }

    private void SpawnPipe()
    {
        float yPos = Random.Range(transform.position.y - heightOffset, transform.position.y + heightOffset);
        Instantiate(pipe, new Vector3(transform.position.x, yPos, 0f), Quaternion.identity);
    }
}
