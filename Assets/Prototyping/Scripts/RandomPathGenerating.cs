using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomPathGenerating : MonoBehaviour
{
    [Header("Stone Age")]
    public GameObject path1;
    public GameObject path2;
    public GameObject path3;
    GameObject[] paths;

    [Header("References")]
    public GameObject player;
    public organizatedRandomNumber randomnums;

    private float lastStart = 0;  
    int i = 0;

    BoxCollider pathLengthCollider;
    void Start()
    {
        //lastStart = player.transform.position.z;
        paths = new GameObject[]
        {
            path1,
            path2,
            path3
        };
        randomnums.max = paths.Length;
        ReferPaths();
    }
    private void FixedUpdate()
    {
        PathLoading();
    }
    public void ReferPaths()
    {
       
        randomnums.Organize();
        Debug.Log(paths[randomnums.list[i]].GetComponent<Transform>().localScale.x);
    }
    public void PathLoading()
    {
        
        if (lastStart - paths[randomnums.list[i]].GetComponent<Transform>().localScale.x *5 <= player.transform.position.z)// if the player reaches the last generated path
        {
            
            Debug.Log("hi" + i);
            GameObject path = Instantiate(paths[randomnums.list[i]],
                new Vector3(0, 0, lastStart), paths[randomnums.list[i]].transform.rotation);
            lastStart += paths[randomnums.list[i]].GetComponent<Transform>().localScale.x *2 - 3; // Add the size of the last placed path           
            i++;
            
        }
        if (i == randomnums.max)
        {
            i = 0;
            ReferPaths();
        }
        
    }
    
}
