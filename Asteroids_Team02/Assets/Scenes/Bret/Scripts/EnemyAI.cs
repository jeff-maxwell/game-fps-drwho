using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float viewRadius;
    public float viewAngle;
    public float rotateToPlayerSpeed;

    public bool playerFound;
    public bool firing = false;

    public LayerMask targetMask;
    public LayerMask obstacleMask;
    public GameObject protonCharge;
    public GameObject firePoint;
    public GameObject[] waypoints;
    public DalekController dalekNavAgent;

    private Vector3 targetLocation;
    private Vector3 dirToTarget;

    private IEnumerator start;
    private IEnumerator fire;

    void Start()
    {
        //dalek = dalekNavAgent.GetNavMeshAgent();
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        dalekNavAgent = GetComponent<DalekController>();
        start = FindTargetsWithDelay(.5f);
        StartCoroutine(start);
        fire = FireSequence();
    }

    void Update()
    {
        if (playerFound) //Rotate its self so that its forward position = players position
        {
            Quaternion rotation = Quaternion.LookRotation(Vector3.Scale(dirToTarget, new Vector3(1f, 0, 1f)));
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotateToPlayerSpeed);
        }
        else
        {
            if (Vector3.Distance(transform.position, dalekNavAgent.GetDestination()) < 1f)
            {
                int num = Random.Range(0, waypoints.Length);
                dalekNavAgent.SetDestination(waypoints[num].transform.position);
            }
        }
    }

    private IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }

   private IEnumerator FireSequence()
    {
        yield return new WaitForSeconds(4f);
        firing = false;
    }

    void FindVisibleTargets()
    {
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            dirToTarget = (target.position - transform.position).normalized;
            if(Vector3.Angle (transform.forward, dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector3.Distance(transform.position, target.position);
                if(!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
                {
                    dalekNavAgent.SetTarget(target.position); //Chase Player
                    playerFound = true;

                    if (firing == false)
                    {
                        GameObject charge = Instantiate(protonCharge, firePoint.transform.position, Quaternion.LookRotation(-transform.forward, Vector3.up), transform); //Load Proton Weapon
                        firing = true; //So we dont fire nonstop
                        StartCoroutine("FireSequence"); //Starts firing coroutine (This basically is just a cooldown for the weapon
                        Destroy(charge, 5f); //Cleans up fire particles
                    }

                    //Debug.Log("I see the target at: " + target.transform.position);
                    //Initiate fire sequence
                    //Fire();
                }
                else
                {
                    playerFound = false;
                }
            }
        }
    }

    public Vector3 DirFromAngle(float angleInDegrees)
    {
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
