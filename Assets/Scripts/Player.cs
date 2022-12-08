using UnityEngine;
using System.Collections;

public abstract class Player : MonoBehaviour
{

    public int health = 4;
    public Sprite sprite;

    protected SpriteRenderer spriteRenderer;
    protected Rigidbody2D body;

    public Transform firePoint;
    public GameObject bullet;

    public HealthBar healthBar;

    public ParticleSystem particleSystem;

    public GameManager gm;

    public abstract void movePlayer();

    public abstract void shoot();

    public abstract void decrementPlayerCount();

    public void setColor(Color color)
    {
        spriteRenderer.color = color;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        } else
        {
            healthBar.setHealth(health);
        }
        
    }

    public void Die()
    {

        Transform position = transform;
        GameObject psParent = new GameObject();

        psParent.transform.position = position.position;

        ParticleSystem ps = Instantiate(particleSystem, psParent.transform);

        decrementPlayerCount();

        Destroy(gameObject);
        Destroy(psParent, 1f);
    }
}
