using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{

    public static character instance;
    
    public float jumpPower;     // 점프 파워
    public bool alive;

    bool once_run;

    Rigidbody2D rigid;                  // 물리
    BoxCollider2D BoxCollider;  // 충돌
    SpriteRenderer spriteRenderer;      // 방향전환
    Animator anim;                      // 애니메이션
    


    void Awake()
    {
        
        if (instance == null) { instance = this; }

        rigid = GetComponent<Rigidbody2D>();
        BoxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }


    void Start()
    {
        alive = true;
    }


    void Update()
    {
        if(GameManager.instance.run && !once_run)
        {
            once_run = true;
            anim.SetBool("run" , true);
        }
    }



    public void Jump()
    {
        if (alive)
        {
            SoundManager.instance.scene_3_jump.Play();
            rigid.AddForce(Vector2.up * jumpPower , ForceMode2D.Impulse);              
            anim.SetBool("jump" , true);
        }
    }


    public void Dead()
    {
        alive = false;
        anim.SetBool("dead", true);
        StartCoroutine(DeadMoveAndDisable());
    }



    // 라이프 -1 될때 왼쪾으로 이동
    IEnumerator DeadMoveAndDisable()
    {
        float moveDuration = 5f;
        float moveSpeed = 2f;
        float elapsed = 0f;

        // Rigidbody2D를 이용해 왼쪽으로 이동
        while (elapsed < moveDuration)
        {
            rigid.linearVelocity = new Vector2(-moveSpeed, rigid.linearVelocity.y);
            elapsed += Time.deltaTime;
            yield return null;
        }

        // 이동 멈추고
        rigid.linearVelocity = Vector2.zero;

        // 게임오브젝트 비활성화
        gameObject.SetActive(false);
    }

    
    void FixedUpdate()
    {
        JumpLandingDetection();
    }



    void JumpLandingDetection()
    {
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position , Vector3.down,1,LayerMask.GetMask("Ground"));

        if (rigid.linearVelocity.y < 0) 
        { 
            anim.SetBool("jump", true);
            Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));
            if (rayHit.collider != null) 
            {            
                if (rayHit.distance < 0.8f)
                {
                    anim.SetBool("jump", false);
                }
            }
        }
    }



}
