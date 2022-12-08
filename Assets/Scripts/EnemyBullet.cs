using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public float speed = 17f;
    public Rigidbody2D rb;


    void Start()
    {
        rb.velocity = -transform.up * speed;
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Teamate")
        {
            Player collidedPlayer = collision.GetComponent<Player>();
            if (collidedPlayer != null)
            {
                collidedPlayer.TakeDamage(1);
            }

            Destroy(gameObject);
        } else if (collision.name == "TopBorder" || collision.name == "BottomBorder")
        {
            Destroy(gameObject);
        }
    }
}
