using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering.Universal;

public class TeamatePlayer : AIPlayer
{
    public Color color = Color.green;

    public override void OnStarting()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = color;
        Light2D glow = transform.GetChild(2).GetComponent<Light2D>();
        glow.color = color;

        focusObject = SelectFocusEnemy();
    }

    public override Transform SelectFocusEnemy()
    {
        List<Transform> enemyTransforms = new List<Transform>();
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemyTransforms.Add(enemy.transform);
        }
        int index = Random.Range(0, enemyTransforms.Count);
        return enemyTransforms[index];
    }

    public override void decrementPlayerCount()
    {
        gm.friendlyTeamNumber -= 1;
    }
}
