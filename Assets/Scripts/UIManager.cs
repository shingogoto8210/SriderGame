using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text textScore;
    [SerializeField] private Text textTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateDisplayScore(int score)
    {
        textScore.text = score.ToString();
    }

    public void UpdateDisplayGameTime(int time)
    {
        textTime.text = time.ToString();
    }
}
