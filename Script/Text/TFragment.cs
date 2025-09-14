using UnityEngine;
using TMPro;

[RequireComponent(typeof(Rigidbody2D))]
public class TFragment : MonoBehaviour
{
    public float jumpForceMin = 10f;            // Y축 점프 최소
    public float jumpForceMax = 12f;            // Y축 점프 최대
    public float horizontalForce = 4f;          // X축 힘 (좌/우)
    public float spinSpeedMin = 0f;             // 최소 회전 속도 (도/초)
    public float spinSpeedMax = 360f;           // 최대 회전 속도 (도/초)

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        if (rb == null) rb = GetComponent<Rigidbody2D>();

        float randomY = Random.Range(jumpForceMin, jumpForceMax);
        float randomX = Random.Range(-horizontalForce, horizontalForce);
        Vector2 jumpDirection = new Vector2(randomX, randomY);
        rb.linearVelocity = jumpDirection;

        float randomSpin = Random.Range(spinSpeedMin, spinSpeedMax) * (Random.value > 0.5f ? 1 : -1);
        rb.angularVelocity = randomSpin;

        rb.gravityScale = 3f; // 중력 적용

        Invoke(nameof(DisableSelf), 3f);
    }


    // void Update()
    // {
    //     if (Input.GetMouseButtonDown(0))
    //     {

    //     }
    // }







    void DisableSelf()
    {
        gameObject.SetActive(false);
        rb.gravityScale = 0f;
        rb.angularVelocity = 0f;
        transform.rotation = Quaternion.identity;
    }
}
