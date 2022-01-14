using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charactor : MonoBehaviour
{
    // Start is called before the first frame update
    public int att;
    public int mapNum;
    public float hp;
    public float maxHp;
    public float stamina = 100;
    public float maxMp;
    public static float mp;
    public static float hpRate = 1f;
    public static float mpRate = 1f;
    public static float staminaRate = 1f;
    public static int money = 1000;
    public static int currentSwordNum;
    public int SwordNum;
    void Start()
    {
        //currentSwordNum = SwordNum;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
