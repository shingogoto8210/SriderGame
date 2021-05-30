using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    [Header("移動速度")]
    public float moveSpeed;
    [SerializeField] private PhysicMaterial pmNoFriction;
    [Header("加速速度")]
    public float accelerationSpeed;
    private bool isGoal;
    private float coefficient = 0.85f;
    private float stopValue = 2.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        if(isGoal == true)
        {
            rb.velocity *= coefficient;
            if(rb.velocity.z <= stopValue)
            {
                rb.velocity = Vector3.zero;
                rb.isKinematic = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.tag == "Goal")
        {
            Debug.Log("Goal");
            isGoal = true;
            Debug.Log(isGoal);
        }
    }

    /// <summary>
    /// 移動
    /// </summary>
    void Move()
    {
        if(isGoal == true)
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

        if(vertical < 0)
        {
            pmNoFriction.dynamicFriction += Time.deltaTime;

            if(pmNoFriction.dynamicFriction > 1.0f)
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
        if(vertical > 0)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, accelerationSpeed);
        }
    }
}
