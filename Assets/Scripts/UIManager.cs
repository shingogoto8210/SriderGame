using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text textScore;
    private PlayerController PC;
    // Start is called before the first frame update
    void Start()
    {
        PC = GameObject.Find("penguin").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateDisplayScore(int score)
    {
        textScore.text = score.ToString();
    }
}
