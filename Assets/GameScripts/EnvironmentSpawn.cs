using System.Net.NetworkInformation;
using UnityEditor;
using UnityEngine;

public class EnvironmentSpawn : MonoBehaviour
{
    public GameObject cloud;
    public Environment moveSpeed;
    private float timer = 0;
    public float heightOffset = 3;
    public float spawnRate = 5;
    private int spawnRand = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnCloud();
    }

    // Update is called once per frame
    void Update()
    {

        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else if (spawnRand == 0)
        {
            spawnRate = Random.Range(0, 10);
            moveSpeed.moveSpeed = Random.Range(3, 10);
            spawnCloud();
            timer = 0;
        }
    }
    void spawnCloud()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        Instantiate(cloud, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 5), transform.rotation);
    }
}
