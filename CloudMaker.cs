using UnityEngine;

public class CloudMaker : MonoBehaviour
{
    public GameObject[] cloudPrefabs;
    public float offsetXMin = -1f;
    public float offsetXMax = 1f;
    public float heightMin = 2f;   // 最低高度
    public float heightMax = 5f;   // 最高高度
    public float makeStartTime = 0.1f;
    public float makeNextTime = 1.5f; // 生成間隔
    public float cloudSpeed = 2f;     // 雲的移動速度

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("MakeClouds", makeStartTime, makeNextTime);
    }

    void MakeClouds()
    {
        int number = Random.Range(0, cloudPrefabs.Length);
        float randomX = Random.Range(offsetXMin, offsetXMax);
        float randomY = Random.Range(heightMin, heightMax);

        GameObject cloud = Instantiate(
            cloudPrefabs[number],
            transform.position + new Vector3(randomX, randomY, 0),
            transform.rotation
        );

        // 設定雲的移動速度
        CloudMove move = cloud.GetComponent<CloudMove>();
        if (move != null)
        {
            move.speed = cloudSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
