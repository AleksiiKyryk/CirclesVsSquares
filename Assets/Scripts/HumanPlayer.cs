using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanPlayer : Player
{
    public float speed = 5f;
    public int numOfBullets = 10;
    Vector2 movement;

    public bool gotAKill;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.cyan;
        healthBar.setHealth(health);
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        gm.updateBullets(numOfBullets);
        gotAKill = false;
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Shoot"))
        {
            shoot();
        }

        if (gotAKill)
        {
            numOfBullets += 3;
            gm.updateBullets(numOfBullets); // update UI
            gotAKill = false;
        }
    }

    private void FixedUpdate()
    {
       movePlayer();
    }

    
    public override void movePlayer()
    {
        body.MovePosition(body.position + movement * speed * Time.deltaTime);
    }

    public override void shoot()
    {
        if (numOfBullets > 0)
        {
            numOfBullets -= 1;
            gm.updateBullets(numOfBullets); // update UI
            GameObject bulletInstance = Instantiate(bullet, firePoint.position, firePoint.localRotation);
            bulletInstance.GetComponent<Bullet>().addPlayer(this);
        } else
        {
            Debug.Log("NO BULLETS CANT SHOOT!!!!!");
        }
    }

    
    public override void decrementPlayerCount()
    {
        gm.MainPlayerAlive = false;
        gm.friendlyTeamNumber -= 1;
    }

}
