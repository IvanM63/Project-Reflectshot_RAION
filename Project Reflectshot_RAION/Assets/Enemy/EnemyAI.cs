using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    [Header("PathFinding")]
    public Transform target;
    public float activateDistance = 50f;
    public float pathUpdateS = 0.5f;

    [Header("Physics")]
    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    public float jumpModifier = 0.3f;
    public float jumpNodeHeightRequirement = 0.8f;   
    public float jumpCekOff = 0.1f;

    [Header("Custom Behavior")]
    public bool followEnabled = true;
    public bool jumpEnabled = true;     
    public bool directionLookEnabled = true;

    Rigidbody2D rb;
    RaycastHit2D isGrounded;
    Seeker seeker;
    private Path path;
    private int currentWaypoint = 0;   
    

    public void Start() {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, pathUpdateS);
    }

    private void FixedUpdate() {
        if (TargetInDistance() && followEnabled) {
            PathFollow();
        }
    }

    private void UpdatePath() {
        if (followEnabled && TargetInDistance() && seeker.IsDone()) {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    private void PathFollow() {
        if (path == null) {
            return;
        }

        //ending path
        if (currentWaypoint >= path.vectorPath.Count) {
            return;
        }

        // cek collision
        Vector3 startOff = transform.position - new Vector3(0f, GetComponent<Collider2D>().bounds.extents.y + jumpCekOff);
        isGrounded = Physics2D.Raycast(startOff, -Vector3.up, 0.05f);

        // ngitung direction
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        // Jumppppp
        if (jumpEnabled && isGrounded) {
            if (direction.y > jumpNodeHeightRequirement) {
                rb.AddForce(Vector2.up * speed * jumpModifier);
            }
        }

        // Movement
        rb.AddForce(force);

        // Next Waypoint
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaypointDistance) {
            currentWaypoint++;
        }

        // flipppp
        if (directionLookEnabled) {
            if (rb.velocity.x > 0.05f) {
                transform.localScale = new Vector3(-1f * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            } else if (rb.velocity.x < -0.05f) {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        }
    }

    private bool TargetInDistance() {
        return Vector2.Distance(transform.position, target.transform.position) < activateDistance;
    }

    private void OnPathComplete(Path p) {
        if (!p.error) {
            path = p;
            currentWaypoint = 0;
        }
    }
}
