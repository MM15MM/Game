using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    //variables useful for enemy movements
    [SerializeField] private Transform LeftEdge;
    [SerializeField] private Transform RightEdge;

    
    [SerializeField] private Transform Knight;

    //walk 
    [SerializeField] private float Speed;
    private bool LeftMovement;
    private Vector3 initScale;
  
    //idle animation
    [SerializeField] private float IdleDuration;
    private float IdleTimer;

    
    [SerializeField] private Animator anim;

    private void Awake()
    {
        initScale = Knight.localScale;
    }
    private void OnDisable()
    {
        anim.SetBool("Walking", false);
    }

    private void Update()
    {
        if (LeftMovement)
        {
            if (Knight.position.x >= LeftEdge.position.x)
                MoveInDirection(-1);
            else
                 FlipDirection();
        }
        else
        {
            if (Knight.position.x <= RightEdge.position.x)
                MoveInDirection(1);
            else
                FlipDirection();
        }
    }

    private void FlipDirection()
    {
        anim.SetBool("Walking", false);
        IdleTimer += Time.deltaTime;

        if (IdleTimer > IdleDuration)
            LeftMovement = !LeftMovement;
    }

    private void MoveInDirection(int dir)
    {
        IdleTimer = 0;
        anim.SetBool("Walking", true);

        //Flip Knight direction
        Knight.localScale = new Vector3(Mathf.Abs(initScale.x) * dir, initScale.y, initScale.z);

        //enemy is moving in that direction
        Knight.position = new Vector3(Knight.position.x + Time.deltaTime * dir * Speed,
            Knight.position.y, Knight.position.z);
    }
}
