using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class TimesSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref Times timesObj) => {
            //简单的时间累加
            timesObj.timeByComponet += 1F * Time.deltaTime;
        });
    }
}
