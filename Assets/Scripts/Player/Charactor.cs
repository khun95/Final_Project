using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charactor : MonoBehaviour
{
    // Start is called before the first frame update
    public int att;
    [SerializeField] protected int mapNum;
    [SerializeField] protected float hp;
    protected float maxHp;
    protected float stamina = 100;
    [SerializeField] protected float maxMp;
    public static float mp;
    public static float hpRate = 1f;
    public static float mpRate = 1f;
    public static float staminaRate = 1f;
    public static int money = 1000;
    public static int currentSwordNum;
}
