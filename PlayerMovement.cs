using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer spr;
    public float Speed = 5f;
    public float Jump = 5f;
    float movement;
    bool isGrounded = false;
    public bool isDead = false;
    public GameObject gameOver;

    
    // start 開始時執行一次
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = true;
            anim.SetBool("jump", false);
            transform.SetParent(other.transform);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = false;
            transform.SetParent(null);
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = true;
            anim.SetBool("jump", false);
            transform.SetParent(other.transform);
        }
        else if (other.CompareTag("Deathline"))
        {
            // Debug.Log("死亡");
            gameOver.SetActive(true);
            isDead = true;
        }
    }

    void Update()
    {
        if (isDead && Input.anyKeyDown)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    // Update is called once per frame
    // update 每一幀執行一次
    // FixedUpdate 每固定時間執行一次 確保物理運算穩定
    void FixedUpdate()
    {
        rb.linearVelocityX = 5f;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            movement = Speed;
            anim.SetBool("run", true);
            spr.flipX = false;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            movement = -Speed;
            anim.SetBool("run", true);
            spr.flipX = true;
        }
        else
        {
            movement = 0f;
            anim.SetBool("run", false);
        }

        rb.linearVelocityX = movement;

        if (Input.GetKey(KeyCode.UpArrow) && isGrounded == true)
        {
            rb.linearVelocity = new Vector2(movement, Jump);
            anim.SetBool("jump", true);
        }
    }
}
