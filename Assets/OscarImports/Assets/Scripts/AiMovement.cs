using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//if you use this code you are contractually obligated to like the YT video
public class AiMovement : MonoBehaviour //don't forget to change the script name if you haven't
{
    public NavMeshAgent agent;
    public float range; //radius of sphere
    private float waitingTime;
    private float stuckTimer;
    private float stuckTimerMax = 2000;

    public Transform centrePoint; //centre of the area the agent wants to move around in
    //instead of centrePoint you can set it as the transform of the agent if you don't care about a specific area
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        Debug.Log(animator);
        agent = GetComponent<NavMeshAgent>();
        WaitingTime();
    }

    void WaitingTime()
    {
        waitingTime = Random.Range(100, 500);
    }
    void StuckFixer()
    {
        bool forloop = true;
        while (forloop)
        {
            Vector3 point;
            if (RandomPoint(centrePoint.position, range, out point)) //pass in our centre point and radius of area
            {
                forloop = false;
                animator.SetBool("isWalking", true);
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); //so you can see with gizmos
                agent.SetDestination(point);
                stuckTimer = stuckTimerMax;
                WaitingTime();
            }
        }
    }
    void Update()
    {
        if (agent.remainingDistance <= agent.stoppingDistance) //done with path
        {
            if(waitingTime <= 0)
            {
                Vector3 point;
                if (RandomPoint(centrePoint.position, range, out point)) //pass in our centre point and radius of area
                {
                    animator.SetBool("isWalking", true);
                    Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); //so you can see with gizmos
                    agent.SetDestination(point);
                    stuckTimer = stuckTimerMax;
                    WaitingTime();
                }
            }
            else
            {
                waitingTime--;
            }
        }
        else if(agent.remainingDistance <= 0.4f)
        {
            animator.SetBool("isWalking", false);
        }
        stuckTimer--;
        if( stuckTimer <= 0)
        {
            StuckFixer();
        }
    }
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        Vector3 randomPoint = center + Random.insideUnitSphere * range; //random point in a sphere 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) //documentation: https://docs.unity3d.com/ScriptReference/AI.NavMesh.SamplePosition.html
        {
            //the 1.0f is the max distance from the random point to a point on the navmesh, might want to increase if range is big
            //or add a for loop like in the documentation
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }


}