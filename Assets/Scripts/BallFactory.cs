using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFactory : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;
    private float x;
    private float z;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        x = Random.Range(-10f, 10f);
        z = Random.Range(275f, 300f);
    }

    // Update is called once per frame
    public void Instantiate()
    {
       
            Instantiate(ballPrefab, new Vector3(x,transform.position.y,z), Quaternion.identity);
            Debug.Log("instantiate");
    }
}
