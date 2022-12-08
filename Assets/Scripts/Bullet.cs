using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;

    private HumanPlayer player;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Player collidedPlayer = collision.GetComponent<Player>();
            if (collidedPlayer != null)
            {
                collidedPlayer.TakeDamage(1);
                if (player != null)
                {
                    if (collidedPlayer.health <= 0)
                    {
                        player.gotAKill = true;
                    }
                }
                
            }

            Destroy(gameObject);
        }
        if (collision.name == "TopBorder" || collision.name == "BottomBorder")
        {
            Destroy(gameObject);
        }
    }

    public void addPlayer(HumanPlayer player)
    {
        this.player = player;
    }
}
