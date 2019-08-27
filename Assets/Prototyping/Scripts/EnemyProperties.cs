using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct Enemy
{
    public int hp;
    public int damage;
    public int xp;
    public int score;
}
public class EnemyProperties : MonoBehaviour
{
    public enum StoneAgeEnemies
    {
        Ihul,
        Atmu,
        Irka,
        Itii,
        Liidu,
        Maraka,
        Unga,
        Heteor,
        Udama,
        Hukka,
        Venkktor,
        Arbama
    }

    public StoneAgeEnemies type = StoneAgeEnemies.Ihul;
    public string testString = "";
    public int testInt = 0;


    //Ihul
    Enemy Ihul = new Enemy();
    public int damage;
    public int xp;
    public int cc;
    public int score;

    //Atmu

    //Irka

    //Itii

    //Liidu

    //Maraka

    //Unga

    //Heteor

    //Udama

    //Hukka

    //Venkktor

    //Arbama

}
