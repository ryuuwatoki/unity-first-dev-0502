using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject player;
    public GameObject ground1;
    public GameObject ground2;
    public GameObject ground3;
    public GameObject ground4;
    public GameObject groundMaker;
    public GameObject cloud1;
    public GameObject cloud2;
    public GameObject cloudMaker;
    public GameObject gameTitle;
    bool gameStarted = false;
    public AudioManager musicPlayer;
    float distance = 0f;
    public TextMeshProUGUI score;
    public TextMeshProUGUI finalScore;
    float finalDistance = 0f;
    public PlayerMovement playerMovement;
    bool isGameOver = false;
    void Start()
    {
        musicPlayer.PlayTitle();
    }


    // Update is called once per frame
    void Update()
    {
        if (gameStarted == false && Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }
        if (gameStarted)
        {
            distance += Time.deltaTime * GroundMove.speed;
            // Debug.Log(distance);
            score.text = $"{distance:F0} メートル突破";
        }
        if (playerMovement.isDead && !isGameOver)
        {
            GameOver();
        }
    }
    void StartGame()
    {
        // 讓速度回到 GroundMaker 的初始速度
        GroundMaker makerScript = groundMaker.GetComponent<GroundMaker>();
        GroundMove.speed = makerScript.initialSpeed;

        // 也順便重設 GroundMaker 的加速狀態
        makerScript.speedUpTimer = 0f;
        makerScript.speedUpCount = 0;

        gameStarted = true;
        score.gameObject.SetActive(true);
        player.SetActive(true);
        ground1.SetActive(true);
        ground2.SetActive(true);
        ground3.SetActive(true);
        ground4.SetActive(true);
        groundMaker.SetActive(true);
        cloud1.SetActive(true);
        cloud2.SetActive(true);
        cloudMaker.SetActive(true);
        gameTitle.SetActive(false);
        musicPlayer.StopAudio();
        musicPlayer.PlayGame();
    }
    public void GameOver()
    {
        isGameOver = true;
        finalDistance = distance;
        score.gameObject.SetActive(false);
        finalScore.gameObject.SetActive(true);
        finalScore.text = $"{finalDistance:F0}";
        if (ground1 != null) ground1.SetActive(false);
        if (ground2 != null) ground2.SetActive(false);
        if (ground3 != null) ground3.SetActive(false);
        if (ground4 != null) ground4.SetActive(false);
        groundMaker.SetActive(false);
        
        groundMaker.GetComponent<GroundMaker>().GameOver(); // 停止生成地面

        // 停止所有已經生成的磚塊運動
        GameObject[] allGrounds = GameObject.FindGameObjectsWithTag("Ground");
        foreach (GameObject ground in allGrounds)
        {
            GroundMove moveScript = ground.GetComponent<GroundMove>();
            if (moveScript != null)
            {
                moveScript.enabled = false; // 停用地面物件的移動
            }
            Destroy(ground);
        }


    }
}
