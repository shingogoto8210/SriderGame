using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFactoryTrigger : MonoBehaviour
{
    [SerializeField] private GameObject Factory;
    private BallFactory ballFactory;
    private bool isTrigger;
    // Start is called before the first frame update
    void Start()
    {
        ballFactory = Factory.GetComponent<BallFactory>();
        isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (isTrigger == false)
        {
            ballFactory.Instantiate();
            Debug.Log("Trigger");
            isTrigger = true;
        }
    }
}
