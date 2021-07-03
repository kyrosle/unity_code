using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator animator;

    BoxCollider2D coll;

    private void Start()
    {
        animator=GetComponent<Animator>();
        coll=GetComponent<BoxCollider2D>();

        coll.enabled=false;

        GameManager.instance.IsDoor(this);
        Debug.Log("door is here!");
    }
    //gamemanager 调用
    public void Opendoor(){
        animator.Play("opening");
        coll.enabled=true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            Debug.Log("next level"); 
            UIManager.instance.NextLevel(); 
        }
    }
}
