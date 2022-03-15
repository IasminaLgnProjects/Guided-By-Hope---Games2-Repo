using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WitchPatrol : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    NavMeshAgent NMAgent;
    Animator anim;

    float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        NMAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        NMAgent.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        GoToWaypoint();

        anim.SetFloat("MoveSpeed", NMAgent.velocity.magnitude*-2);

        if(Input.GetKeyDown(KeyCode.F))
        {
            //stop moving
            anim.SetBool("Throwing", true);
        }
    }

    void GoToWaypoint()
    {
        NMAgent.SetDestination(waypoints[0].transform.position);
    }
}
