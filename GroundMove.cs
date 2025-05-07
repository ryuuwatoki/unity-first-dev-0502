using UnityEngine;

public class GroundMove : MonoBehaviour
{
    public static float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);

        if (transform.position.x < -25f)
        {
            Destroy(gameObject);
        }
    }
}
