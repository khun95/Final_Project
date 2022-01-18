using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class SkeletonMage : Monster
{
    [SerializeField] GameObject ball;
    [SerializeField] GameObject ballPos;
    ////public bool isSpawn = false;
    //public bool isEnter = false;
    //Vector3 originPos;
    public Attribute Attribute;
    private new void Start()
    {
        base.Start();
        monsterType = 2;

    }
    void ShootingBall()
    {
        GameObject temp = Instantiate(ball, ballPos.transform.position, Quaternion.identity);
        temp.GetComponent<Bullet>().att = skillAtt;
    }
    void Update()
    {
        HPCheck();
        Die();
        MonsterMove(player, 10, 10, 15);
    }

}
