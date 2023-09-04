using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    NavMeshAgent navMesh;
    public GameObject player;

    float distance;
    public float maxFollowDistance ;
    public float DistanceToStop ;


    Animator enmeyAnimator;

   private void Awake()
    {
        navMesh = GetComponent<NavMeshAgent>();
        enmeyAnimator = GetComponent<Animator>();
    }
    private void Update()
    {
        Seeking();
    }
    void Seeking()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance > DistanceToStop && distance < maxFollowDistance) // ระยะการมองเห็น
        {
            navMesh.SetDestination(player.transform.position);
            
        }
        else
        {
            navMesh.SetDestination(transform.position);
            
        }
    }



}
