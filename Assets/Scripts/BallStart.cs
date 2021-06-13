using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallStart : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    private Rigidbody rb;
    private float x;
    // Start is called before the first frame update
    void Start()
    {
        rb = ball.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        x = Random.Range(-45f, 45f);
        transform.eulerAngles = new Vector3(0, x, 0);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Ballstart();
        }
    }

    public void Ballstart()
    {
        rb.isKinematic = false;
        rb.AddForce(transform.forward * 10000f);
    }
}
