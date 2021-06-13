using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private int Score;

    // Start is called before the first frame update
    void Start()
    {
        Score = PlayerController.GetScore();
        scoreText.text = Score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
