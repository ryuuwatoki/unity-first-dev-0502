using UnityEngine;

public class CloudMove : MonoBehaviour
{
    public float speed = 2f;

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // 雲移出畫面自動銷毀
        if (transform.position.x < -15f)
        {
            Destroy(gameObject);
        }
    }
}
