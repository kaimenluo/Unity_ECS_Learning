/***
 *
 * Hybrid ECS演示项目
 *
 * Title: 系统
 *
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics; 

public class MovementSystem : ComponentSystem
{
    protected override void OnUpdate() {
        Entities.ForEach((ref Translation translation,ref Movement movement) => {
            translation.Value.y += movement.MoveSpeed * Time.deltaTime;
            //调转方向
            if (translation.Value.y > 4F) {
                movement.MoveSpeed = -Mathf.Abs(movement.MoveSpeed);
            }
            if (translation.Value.y < -1F)
            {
                movement.MoveSpeed = Mathf.Abs(movement.MoveSpeed);
            }
        });
    }

} //class end
