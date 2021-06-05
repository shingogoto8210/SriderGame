using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    [Header("移動速度")]
    public float moveSpeed;
    [SerializeField] private PhysicMaterial pmNoFriction;
    [Header("加速速度")]
    public float accelerationSpeed;
    [Header("ジャンプ力")]
    public float jumpPower;
    private bool isGoal;
    private float coefficient = 0.955f;
    private float stopValue = 2.5f;
    [SerializeField, Header("地面判定用レイヤー")]
    private LayerMask groundLayer;
    [SerializeField, Header("斜面との接地判定")]
    private bool isGround;
    private Animator anim;
    public int score;
    [SerializeField] private UIManager UImanager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        //移動
        Move();
    }

    private void Update()
    {
        Brake();
        Accelerate();
        if (isGoal == true)
        {
            rb.velocity *= coefficient;
            if (rb.velocity.z <= stopValue)
            {
                rb.velocity = Vector3.zero;
                rb.isKinematic = true;
            }
        }

        CheckGround();
        if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {
            Jump();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Goal")
        {
            Debug.Log("Goal");
            isGoal = true;
        }
    }

    /// <summary>
    /// 移動
    /// </summary>
    void Move()
    {
        if (isGoal == true)
        {
            return;
        }
        float x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(x * moveSpeed, rb.velocity.y, rb.velocity.z);
    }

    /// <summary>
    /// ブレーキ
    /// </summary>
    void Brake()
    {
        float vertical = Input.GetAxis("Vertical");

        if (vertical < 0)
        {
            pmNoFriction.dynamicFriction += Time.deltaTime;

            if (pmNoFriction.dynamicFriction > 1.0f)
            {
                pmNoFriction.dynamicFriction = 1.0f;
            }
        }
        else
        {
            pmNoFriction.dynamicFriction = 0;
        }
    }

    /// <summary>
    /// 加速
    /// </summary>
    void Accelerate()
    {
        float vertical = Input.GetAxis("Vertical");
        if (vertical > 0)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, accelerationSpeed);
        }
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpPower);
        anim.SetTrigger("jump");
    }

    private void CheckGround()
    {
        isGround = Physics.Linecast(transform.position, transform.position - transform.up * 0.3f, groundLayer);
        Debug.DrawLine(transform.position, transform.position - transform.up * 0.3f, Color.red);
    }

    /// <summary>
    /// スコア加算
    /// </summary>
    /// <param name="point"></param>
    public void AddScore(int point)
    {
        score += point;
        UImanager.UpdateDisplayScore(score);
    }
}
