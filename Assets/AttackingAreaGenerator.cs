using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class AttackingAreaGenerator : MonoBehaviour
{
    public static AttackingAreaGenerator aiAttackingAreaGen;
    public agentAi agentAiSystem;
    public float frontSideLength;
    public float backSideLength;
    public float length;
	public float height = 1;
    Vector3[] vertices;
    int[] triangles;
    Mesh mesh;

	public bool playerInAttackingArea = false;
    // Welcome Nandu :)
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        
        GenerateAttackingArea();
        ApplyAttackingArea();
        GetComponent<MeshCollider>().sharedMesh = mesh;
    }

    public void GenerateAttackingArea()
    {
        vertices = new Vector3[]
        {
			//top
            new Vector3(frontSideLength / 2* -1,0,length),
            new Vector3(0,0,length),
            new Vector3(frontSideLength / 2,0,length),
            new Vector3(backSideLength / 2,0,0),
            new Vector3(backSideLength / 2 * -1,0,0),
			// down
			new Vector3(frontSideLength / 2* -1,height*-1,length),
			new Vector3(0,height*-1,length),
			new Vector3(frontSideLength / 2,height*-1,length),
			new Vector3(backSideLength / 2,height*-1,0),
			new Vector3(backSideLength / 2 * -1,height*-1,0)
		};


        triangles = new int[] {
			//top
			0,1,4,
            1,3,4,
            1,2,3,
			//down
			5,6,9,
			6,8,9,
			6,7,8,
			//left
			0,9,5,
			0,4,9,
			//right
			8,3,2,
			2,7,8,
			//front
			7,5,0,
			0,2,7
        };

    }
    public void ApplyAttackingArea()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInAttackingArea = true;
            agentAiSystem.agent.isStopped = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {          
            Vector3 lookAtRotation = Quaternion.LookRotation(agentAiSystem.target.position - transform.position).eulerAngles;
            transform.rotation = Quaternion.Euler(Vector3.Scale(lookAtRotation,agentAiSystem.rotationMask));
            transform.parent.rotation = Quaternion.Euler(Vector3.Scale(lookAtRotation, agentAiSystem.rotationMask));
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInAttackingArea = false;
        }
    }

   
	

	public bool playerIsAttackable()
	{
		return playerInAttackingArea;
	}
}
