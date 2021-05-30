using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotateObject : MonoBehaviour
{
    [Header("回転秒数")]
    public float duaring;

    private bool isRotate;


    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.tag == "Player" && isRotate ==false)
        {
            Rotate();
        }
    }

    private void Rotate()
    {
        Vector3 Rotation = new Vector3(0, 0, RotateAngle());
        transform.DORotate(Rotation, duaring);
        isRotate = true;
    }

    private float RotateAngle()
    {
        int value = Random.Range(0, 2);
        //return value == 0 ? 70 : -70; 
        if(value == 0)
        {
            return 70f;
        }
        else
        {
            return -70f;
        }
    }
}
