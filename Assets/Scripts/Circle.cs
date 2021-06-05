using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    //private PlayerController PC;
    public int point;
    // Start is called before the first frame update
    void Start()
    {
        //PC = GameObject.Find("penguin").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        {
            //PC.AddScore(point);
            if(other.gameObject.TryGetComponent(out PlayerController player))
            {
                player.AddScore(point);
            }
            Destroy(gameObject, 0.5f);
        }
    }
}
