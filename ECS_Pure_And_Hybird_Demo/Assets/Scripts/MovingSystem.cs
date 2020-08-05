using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class MovingSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref Translation translation, ref Moving moving) => {
            translation.Value.y += moving.MoveSpeed * Time.deltaTime;
            //调转方向
            if (translation.Value.y > 6F)
            {
                moving.MoveSpeed = -Mathf.Abs(moving.MoveSpeed);
            }
            if (translation.Value.y < -6F)
            {
                moving.MoveSpeed = Mathf.Abs(moving.MoveSpeed);
            }
        });
    }
}
