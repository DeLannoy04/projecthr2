using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.AI;

public class agentAi : MonoBehaviour
{
    
	[Header("Ai settings")]
    [HideInInspector]
	public NavMeshAgent agent;	
	public GameObject weapon;
    public Vector3 rotationMask;
    [HideInInspector]
    public Transform target;
    NavMeshSurface navMeshSurf;
    AttackingAreaGenerator attackingAreaGenerator;
    public float combatTime = 0.1f;

	private float nextTimeToAttack = 0.0f;

	bool isAttacking;


	private void Start()
	{
		agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        navMeshSurf = GameObject.Find("NavMesh").GetComponent<NavMeshSurface>();
        navMeshSurf.BuildNavMesh();
	}

	void Update()
    {
        agent.SetDestination(target.position);

        if (target.position.z >= transform.position.z)
			Destroy(gameObject);
       if(GetComponentInChildren<AttackingAreaGenerator>().playerIsAttackable())
		{
			Attack();
		}
		if (isAttacking == true)
        {
            GameObject.FindGameObjectWithTag("Enemy Weapon").transform.Translate(Vector3.forward, Space.Self);
        }
       
	}
    

    public void Attack()
    {
        if (Time.time >= nextTimeToAttack && !isAttacking)
        {
            nextTimeToAttack = Time.time + combatTime;
            GameObject go = Instantiate(weapon, transform.position + new Vector3(0, 0, 1), Quaternion.identity);
            go.transform.LookAt(target);
            go.gameObject.tag = "Enemy Weapon";
            isAttacking = true;
        }
        if (isAttacking && GameObject.FindGameObjectWithTag("Enemy Weapon").transform.position.z <= target.transform.position.z)
        {
            Destroy(GameObject.FindGameObjectWithTag("Enemy Weapon"));
            isAttacking = false;
            
        }
    }

	
}
