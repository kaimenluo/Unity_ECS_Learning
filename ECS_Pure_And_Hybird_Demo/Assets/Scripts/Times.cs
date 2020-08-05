/***
 *
 * Pure ECS演示项目
 *
 * 组件: 时间
 *
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.Entities;

public struct Times : IComponentData
{
    public float timeByComponet;
}
