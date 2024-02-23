using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    [SerializeField] GameObject pointA;
    [SerializeField] GameObject pointB;
    [SerializeField] float speed;

    private Rigidbody2D rb;
    private Animator animator;
    private Transform currentPoint;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentPoint = pointB.transform;
        animator.Play("ant_run");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if(currentPoint == pointB.transform)
        {
            rb.velocity =( new Vector2 (speed,0));
        }
        if (currentPoint == pointA.transform)
        {
            rb.velocity =(new Vector2( - speed, 0));
        }
        if(Vector2.Distance(transform.position, pointB.transform.position)<1f )
        {
            currentPoint = pointA.transform;
        }
        if (Vector2.Distance(transform.position, pointA.transform.position) < 1f)
        {
            currentPoint = pointB.transform;
        }
        if(point.x >0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        
    }
    private void OnDrawGizmos()
    {
        if (rb != null)
        {
            Gizmos.DrawWireSphere(pointA.transform.position,0.5f);
            Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
            Gizmos.DrawLine(pointA.transform.position,pointB.transform.position);
        }
    }
}
