using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TFragment_coin : MonoBehaviour
{
    public float jumpForceMin = 10f;            // Y축 점프 최소
    public float jumpForceMax = 12f;            // Y축 점프 최대
    public float horizontalForce = 4f;          // X축 힘 (좌/우)
    public bool move;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        if (move)
        {
            rb.linearVelocity = new Vector2(-2f, rb.linearVelocity.y);
        }
    }

    void OnEnable()
    {
        if (rb == null) rb = GetComponent<Rigidbody2D>();

        float randomY = Random.Range(jumpForceMin, jumpForceMax);
        float randomX = Random.Range(-horizontalForce, horizontalForce);
        Vector2 jumpDirection = new Vector2(randomX, randomY);
        rb.linearVelocity = jumpDirection;

        rb.gravityScale = 3f; // 중력 적용

        Invoke(nameof(DisableSelf), 3f);
    }

    void DisableSelf()
    {
        gameObject.SetActive(false);
        rb.gravityScale = 0f;
        rb.angularVelocity = 0f;  // 혹시 모를 이전 값 제거용 (안 넣어도 무방)
        transform.rotation = Quaternion.identity; // 회전값 초기화
    }




    void OnCollisionEnter2D(Collision2D collision)
    {
        // 닿은 대상의 레이어가 Ground인지 체크
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            move= true;
        }
    }

}
