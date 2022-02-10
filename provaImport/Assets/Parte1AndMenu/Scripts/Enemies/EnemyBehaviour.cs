using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    //variables useful for enemy movements
    [SerializeField] private Transform LeftEdge;
    [SerializeField] private Transform RightEdge;

    //enemy
    [SerializeField] private Transform enemy;

    //walk 
    [SerializeField] private float Speed;
    private bool LeftMovement;
    private Vector3 initScale;
  
    //idle animation
    [SerializeField] private float IdleDuration;
    private float IdleTimer;


   //animator

    [SerializeField] private Animator anim;

    private void Awake()
    {
        initScale = enemy.localScale;
    }
    private void OnDisable()
    {
        anim.SetBool("Walk", false);
    }

    private void Update()
    {
        if (LeftMovement)
        {
            if (enemy.position.x >= LeftEdge.position.x)
                MoveInDirection(-1);
            else
                 FlipDirection();
        }
        else
        {
            if (enemy.position.x <= RightEdge.position.x)
                MoveInDirection(1);
            else
                FlipDirection();
        }
    }

    private void FlipDirection()
    {
        anim.SetBool("Walk", false);
        IdleTimer += Time.deltaTime;

        if (IdleTimer > IdleDuration)
            LeftMovement = !LeftMovement;
    }

    private void MoveInDirection(int dir)
    {
        IdleTimer = 0;
        anim.SetBool("Walk", true);

        //Flip dragon direction
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * dir, initScale.y, initScale.z);

        //enemy is moving in that direction
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * dir * Speed,
            enemy.position.y, enemy.position.z);

    }

}
