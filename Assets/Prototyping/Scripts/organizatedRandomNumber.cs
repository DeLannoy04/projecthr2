using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class organizatedRandomNumber : MonoBehaviour
{
    public static organizatedRandomNumber randomnums;
	float Rand;
    [SerializeField]
	public int max;
	public List<int> list = new List<int>();

	void Start()
	{

        
	}
    public void Organize()
    {        
        list = new List<int>(new int[max]);
        for(int i = 0;i < max;i++)
        {
            list[i] = i;
        }
     
        list = list.OrderBy(i => Random.value).ToList();


    }
}
