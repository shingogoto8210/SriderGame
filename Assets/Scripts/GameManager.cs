using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;

    [Header("ゲーム時間")]
    public int gameTime;

    private float timeCounter;

    [SerializeField] private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        uiManager.UpdateDisplayGameTime(gameTime);
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime;

        if (timeCounter >= 1.0f)
        {
            timeCounter = 0;

            gameTime--;


            if (gameTime <= 0)
            {
                gameTime = 0;
                SceneManager.LoadScene("GameOver");
            }
            uiManager.UpdateDisplayGameTime(gameTime);
        }

        if(player.transform.position.y <= -300)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
