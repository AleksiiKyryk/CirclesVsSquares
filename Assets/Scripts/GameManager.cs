using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int friendlyTeamNumber;
    public int enemyTeamNumber;
    public bool MainPlayerAlive;
    public bool gameOver;

    public GameObject UI;
    public Text Reason;

    public Text bulletsNumber;

    // Start is called before the first frame update
    void Start()
    {
        friendlyTeamNumber = 4;
        enemyTeamNumber = 4;
        MainPlayerAlive = true;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    { 
        if (friendlyTeamNumber == 0)
        {
            // Enemy (Red) Team Won
            gameOver = true;
            UI.SetActive(true);
            Reason.text = "The Red Team WON!";
        }

        if (enemyTeamNumber == 0)
        {
            // Friendly (Blue) Team Won
            gameOver = true;
            UI.SetActive(true);
            Reason.text = "The Green Team WON!";
        }

        if (MainPlayerAlive == false)
        {
            // Main Player Died
            gameOver = true;
            UI.SetActive(true);
            Reason.text = "YOU DIED!";
        }
    }

    public void updateBullets(int bullets)
    {
        bulletsNumber.text = bullets.ToString();
    }

    public void Replay()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
