using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class JumpUpObject : MonoBehaviour
{
    private Vector3 upPosition;
    
    void Start()
    {
        //モグラの最初の位置を取得する
        upPosition = transform.position;
        //モグラを地面の中に入れる
        Hide();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            HeadUp();
        }
    }

    void Hide()
    {
        transform.Translate(0, -2.0f, 0);
    }

    public void HeadUp()
    {
        //transform.position = upPosition;
        transform.DOMoveY(upPosition.y, 0.25f);
    }
}
