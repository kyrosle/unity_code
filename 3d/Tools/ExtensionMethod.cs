using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 扩展方法
// 把这个方法插入到transfrom里面
public static class ExtensionMethod 
{
   //
   private const float dotThreshold=0.5f;
   // 判断敌人视觉扇
   public static bool IsFacingTarget(this Transform transform,Transform target){
      // 相对位置
      var vectorToTarget=target.position-transform.position;
      // 得到向量的方向
      vectorToTarget.Normalize();

      // 
      float dot=Vector3.Dot(transform.forward,vectorToTarget);
      return dot >= dotThreshold;
   }
}
// Vector3.Dot
// public static float Dot(Vector3 this, Vector3 rhs);
// 物体面向 Vector3 forward = transform.TransformDirection(Vector3.forward);
// 目标位置 Vector3 toOther = other.position - transform.position;
// 两个向量的点积
