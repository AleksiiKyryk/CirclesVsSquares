using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIPlayer : Player
{
    public float speed = 3f;
    Vector2 movement;

    public Transform focusObject;

    private float timeLeft;
    public float accelarationTime = 1.5f;

    private void Start()
    {
        OnStarting();
        healthBar = GetComponentInChildren<HealthBar>();
        healthBar.setHealth(health);
        firePoint = transform.GetChild(0);
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public abstract void OnStarting();

    private void Update()
    {
        if (!gm.gameOver)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                movement = DetermineMove();
                timeLeft += accelarationTime;
                if (Random.Range(-1f, 1f) > 0f)
                {
                    shoot();
                }
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movePlayer();
    }

    public override void movePlayer()
    {
        body.MovePosition(body.position + movement * speed * Time.deltaTime);
    }

    public Vector2 DetermineMove()
    {

        float xDirection = 0f;
        float yDirection = 0f;

        if (focusObject != null)
        {
            Vector3 myPosition = transform.position;
            Vector3 focusPosition = focusObject.position;
            Vector3 distance = focusPosition - myPosition;

            float error = Random.Range(-0.2f, 0.3f);

            if (distance.x > 0)
            {
                xDirection = 1f + error;
                yDirection = 0f + error;

            }
            else if (distance.x < 0)
            {
                xDirection = -1f + error;
                yDirection = 0f + error;
            }
            

            //Debug.Log("moving towards the enemy at position: " + focusPosition + ", my diretion is " + xDirection + ", " + yDirection);


            return new Vector2(xDirection, yDirection);
        } else
        {
            xDirection = Random.Range(-1f, 1f);
            yDirection = Random.Range(-1f, 1f);

            return new Vector2(xDirection, yDirection);
        }
        
    }

    public override void shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.localRotation);
    }

    public abstract Transform SelectFocusEnemy();
}
