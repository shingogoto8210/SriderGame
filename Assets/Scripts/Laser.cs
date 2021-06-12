using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Laser : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private JumpUpObject j;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            j.HeadUp();
        }
    }
}
