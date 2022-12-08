using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyPlayer : AIPlayer
{
    // Colors
    private static readonly float r = 197;
    private static readonly float g = 136;
    private static readonly float b = 75;
    Color color = new Color(r, g, b);

    public override void OnStarting()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = color;
        focusObject = SelectFocusEnemy();
    }

    public override void decrementPlayerCount()
    {
        gm.enemyTeamNumber -= 1;
    }

    public override Transform SelectFocusEnemy()
    {
        List<Transform> enemyTransforms = new List<Transform>();
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Teamate"))
        {
            enemyTransforms.Add(enemy.transform);
        }
        int index = Random.Range(0, enemyTransforms.Count);
        return enemyTransforms[index];
    }

    public override void shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.localRotation);
    }
}
