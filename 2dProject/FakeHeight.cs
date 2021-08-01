﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FakeHeight : MonoBehaviour
{
    public Color color;

    public Transform transObject;
    public Transform transBody;
    public Transform transShadow;

    public float gravity = -10;
    public Vector2 groundVelocity;
    public float verticalVeloocity;

    public bool isGrounded;
    public UnityEvent onGroundHitEvent;
    private float lastInitialVerticalVelocity;

    #region 
    private Animator animator;
    public GameObject exlposionEffect1;
    public GameObject exlposionEffect2;
    #endregion

    private void Start()
    {
        transform.GetChild(0).GetComponent<SpriteRenderer>().color = color;
        animator = GetComponent<Animator>();

        StartCoroutine(Boom());
    }

    private void Update()
    {
        UpdatePosition();
        CheckGround();
    }

    //MARKER 当角色射击时，调用这个脚本
    public void Initialize(Vector2 _groundVelocity, float _verticalVelocity)
    {
        isGrounded = false;//CORE 第二次弹起来，只有当isGrounded等于True，UpdatePosition方法中才能执行向上移动的代码

        this.groundVelocity = _groundVelocity;
        this.verticalVeloocity = _verticalVelocity;

        lastInitialVerticalVelocity = verticalVeloocity;//MARKER 为Bounce第二次弹跳作准备
    }

    private void UpdatePosition()
    {
        if (!isGrounded)
        {
            verticalVeloocity += gravity * Time.deltaTime;
            transBody.position += new Vector3(0, verticalVeloocity, 0) * Time.deltaTime;
        }
        transObject.position += (Vector3)groundVelocity * Time.deltaTime;
    }

    void CheckGround()
    {
        if (transBody.position.y < transObject.position.y && !isGrounded)
        {
            transBody.position = transObject.position;//只是保证melon不会在shadow下方
            isGrounded = true;

            GroundHit();
        }
    }

    //MARKER 在CheckGround方法中调用
    void GroundHit()
    {
        onGroundHitEvent.Invoke();
    }

    public void Stick()
    {
        groundVelocity = Vector2.zero;
    }

    public void Bounce(float _factor)
    {
        Initialize(groundVelocity, lastInitialVerticalVelocity / _factor);
    }

    public void SlowGroundVelocity(float _factor)
    {
        groundVelocity = groundVelocity / _factor;
    }

    IEnumerator Boom()
    {
        yield return new WaitForSeconds(1.2f);
        animator.SetTrigger("Active");
    }

    public void Explosion()
    {
        Instantiate(exlposionEffect1, transBody.position, Quaternion.identity);
        Instantiate(exlposionEffect2, transBody.position, Quaternion.identity);
        Destroy(gameObject);
        FindObjectOfType<CameraController>().ScreenShake(0.75f);
    }
}
