using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 攻击 判定区域
public class HitPoint : MonoBehaviour
{
    int dir;
    public bool bomebAvilable;
    public  void OnTriggerEnter2D(Collider2D other)
    {
        if(transform.position.x>other.transform.position.x){
            dir =-1;
        }else
            dir=1;
        if(other.CompareTag("player"))
        {
            other.GetComponent<IDamageable>().GetHit(1);
        }
        if(bomebAvilable&&other.CompareTag("Bomb"))
        {
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(dir,1)*10,ForceMode2D.Impulse);
        }
    } 

}
