using UnityEngine;

public class GroundMaker : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    [Header("プレハブ配列 | 預製物陣列")]
    public GameObject[] prefabs;


    [Header("最初速度 | 初速度")]
    public float initialSpeed = 3f; // 可以在 Inspector 設定


    [Header("Xオフセット最小 | X偏移min")]
    public float offsetMin = -1f;


    [Header("Xオフセット最大 | X偏移max")]
    public float offsetMax = 1f;


    [Header("Yオフセット最小 | Y偏移min")]
    public float yOffsetMin = 0f;


    [Header("Yオフセット最大 | Y偏移max")]
    public float yOffsetMax = 0f;


    [Header("スタートタイム | 開始時間(秒)")]
    public float StartTime = 0.1f;


    [Header("生成間隔 | 生成間隔時間(秒)")]
    public float NextTime = 0.7f;


    [Header("加速計時器 | 加速タイマー")]
    public float speedUpTimer = 0f;


    [Header("加速間隔 | 加速間隔時間(秒)")]
    public float speedUpInterval = 10f; // 每10秒加速

    [Header("目前加速次數 | 現在加速回数")]
    public int speedUpCount = 0;


    [Header("最大加速回数 | 最大加速次數")]
    public int maxSpeedUpCount = 5; // 可自行調整最大加速次數


    [Header("加速倍率 | 每次加速(倍)")]
    public float speedUpAmount = 1.1f;


    int groundCount = 0;


    void Start()
    {
        GroundMove.speed = initialSpeed; // 設定初始速度
        InvokeRepeating("MakeGrounds", StartTime, NextTime);
        Debug.Log($"目前速度：{GroundMove.speed:F2}");

    }

    void Update()
    {
        speedUpTimer += Time.deltaTime;
        if (speedUpTimer >= speedUpInterval && speedUpCount < maxSpeedUpCount)
        {
            GroundMove.speed += speedUpAmount; // 使用變數控制加速幅度
            Debug.Log($"加速！目前速度：{GroundMove.speed:F2}");
            speedUpTimer = 0f;
            speedUpCount++; // 累加加速次數
        }
    }

    // Update is called once per frame
    void MakeGrounds()
    {
        int number = Random.Range(0, prefabs.Length);
        float xOffset = Random.Range(offsetMin, offsetMax);
        float yOffset = Random.Range(yOffsetMin, yOffsetMax);
        Instantiate(prefabs[number],
        transform.position + new Vector3(xOffset, yOffset, 0),
        transform.rotation);
        groundCount++;
        // Debug.Log("第" + groundCount + "個地面");
    }

    public void GameOver()
    {
        CancelInvoke("MakeGrounds");
        this.enabled = false; // 停用腳本本身（包含 Update()）
    }

}