using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WitchPatrol : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    NavMeshAgent NMAgent;
    Animator anim;

    [SerializeField] float speed = 1f;
    float reachTargetRange = 2f;
    [SerializeField] int currentWaypoint = 0;


    float sightDistance = 9f;
    Vector3 raycastDirection;
    float currentSightAngle = 0f;
    float scanSpeed = 150f;
    float maxScanAngle = 45f;
    bool throwPotion;

    public bool getThrowPotion
    { get 
        {
            return throwPotion;
        }
    }

    void Start()
    {
        NMAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        NMAgent.speed = speed;
        GoToWaypoint();
    }

    // Update is called once per frame
    void Update()
    {
        GoToWaypoint();

        anim.SetFloat("MoveSpeed", NMAgent.velocity.magnitude*-2);

        if(NMAgent.remainingDistance < reachTargetRange)
        {
            GoToWaypoint();
        }

        ScanForPlayer();

    }

    void GoToWaypoint()
    {
        currentWaypoint++;
        if(currentWaypoint >= waypoints.Length)
        {
            currentWaypoint = 0;
        }
        NMAgent.SetDestination(waypoints[currentWaypoint].transform.position);
    }

    void ScanForPlayer()
    {
        currentSightAngle += scanSpeed * Time.deltaTime;
        currentSightAngle = currentSightAngle % maxScanAngle;

        float angle = currentSightAngle * 2 - maxScanAngle; //sweep left to right
        raycastDirection = transform.TransformDirection(Quaternion.Euler(0, angle, 0) * Vector3.forward) * sightDistance;

        RaycastHit hit;
        if(Physics.Raycast(transform.position + new Vector3(0, 1f, 0), raycastDirection, out hit, sightDistance) && hit.collider.tag == "Player") //+ Vector3 because the raycast was at the feet
        {
            Debug.Log("player found");
            Debug.DrawRay(transform.position + new Vector3(0, 1f, 0), raycastDirection, Color.red);

            throwPotion = true;
        }
        else
        {
            Debug.DrawRay(transform.position + new Vector3(0, 1f, 0), raycastDirection, Color.green);

            throwPotion = false;
        }
    }

    public void Throw()
    {
        //rbAxe.transform.parent = null;
        //rbAxe.isKinematic = false;
        //rbAxe.AddForce(Camera.main.transform.TransformDirection(Vector3.forward) * power, ForceMode.Impulse);
        //rbAxe.AddTorque(rbAxe.transform.TransformDirection(Vector3.right) * 300, ForceMode.Impulse);

        //isReturning = false;
    }

}
