using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WitchAnim : MonoBehaviour
{
    Animator anim;
    NavMeshAgent NMAgent;
    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
        //NMAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //anim.SetFloat("MoveSpeed", NMAgent.velocity.magnitude);
    }
}
