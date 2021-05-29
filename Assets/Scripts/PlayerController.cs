using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("移動速度")]
    public float moveSpeed;
    private Rigidbody rb;
    [SerializeField] private PhysicMaterial pmNoFriction;

    [Header("加速速度")]
    public float accelerationSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //移動
        Move();
    }

    private void Update()
    {
        Brake();
        Accelerate();
    }

    /// <summary>
    /// 移動
    /// </summary>
    void Move()
    {
        float x = Input.GetAxis("Horizontal");

        rb.velocity = new Vector3(x * moveSpeed, rb.velocity.y, rb.velocity.z);

        Debug.Log(rb.velocity);
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
        Debug.Log(pmNoFriction.dynamicFriction);
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
