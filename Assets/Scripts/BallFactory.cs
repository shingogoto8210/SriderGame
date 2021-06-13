using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFactory : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;
    private float x;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        x = Random.Range(-5f, 5f);
    }

    // Update is called once per frame
    public void Instantiate()
    {
       
            Instantiate(ballPrefab, new Vector3(x,transform.position.y,transform.position.z), Quaternion.identity);
            Debug.Log("instantiate");
    }
}
