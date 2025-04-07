using UnityEngine;

public class Environment : MonoBehaviour
{
    public float moveSpeed = 2;
    public float deadZone = -35;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // pipe movement
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        // pipe deletion
        if (transform.position.x < deadZone)
        {
            Debug.Log("Cloud Deleted");
            Destroy(gameObject);
        }
    }
}
