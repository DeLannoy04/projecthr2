using System.Collections;
using System.Collections.Generic;
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

        for (int j = 0; j < max -1; j++)
        {
            Rand = Random.Range(0, max -1);

            while (list.Contains(System.Convert.ToInt32(Rand)))
            {
                Rand = Random.Range(0, max -1);
            }

            list[j] = System.Convert.ToInt32(Rand);
            print(list[j]);
        }
        

    }
}
