using UnityEngine;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerCircle;
    public GameObject enemySquare;
    private int numberOfPlayers = 3;


    void Start()
    {
        //Spawn teamates
        SpawnTeamates(numberOfPlayers);

        // Spawn Enemies
        SpawnEnemies(numberOfPlayers);
    }

    void SpawnTeamates(int numOfTeamates)
    {
        for (int i = 0; i < numOfTeamates; i++)
        {
            GameObject teamate = GameObject.Instantiate(playerCircle);
            teamate.name = "Teamate " + i;
            teamate.tag = "Teamate";
            Vector3 position = playerCircle.transform.position;
            if (i == 0)
            {
                position.x -= 2.5f;
            }
            else
            {
                position.x += (i * 2.5f);
            }
            teamate.transform.position = position;

            // Remove HumanPlayer
            GameObject bullet = playerCircle.GetComponent<HumanPlayer>().bullet;
            HealthBar healthBar = playerCircle.GetComponent<HumanPlayer>().healthBar;
            ParticleSystem ps = playerCircle.GetComponent<HumanPlayer>().particleSystem;
            Destroy(teamate.GetComponent("HumanPlayer"));


            teamate.AddComponent<TeamatePlayer>();
            teamate.GetComponent<TeamatePlayer>().bullet = bullet;
            teamate.GetComponent<TeamatePlayer>().healthBar = healthBar;
            teamate.GetComponent<TeamatePlayer>().particleSystem = ps;



        }
    }

    void SpawnEnemies(int numOfEnemies)
    {
        for (int i = 0; i < numOfEnemies; i++)
        {
            GameObject enemy = GameObject.Instantiate(enemySquare);
            enemy.name = "Enemy " + i;
            enemy.tag = "Enemy";
            Vector3 position = enemySquare.transform.position;
            if (i == 0)
            {
                position.x -= 2.5f;
            }
            else
            {
                position.x += (i * 2.5f);
            }
            enemy.transform.position = position;
        }


    }
}
