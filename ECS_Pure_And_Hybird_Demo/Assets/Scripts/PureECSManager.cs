using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.Entities;
using Unity.Transforms;
using Unity.Collections;
using Unity.Rendering;

public class PureECSManager : MonoBehaviour
{
    public int PlaneCreateNumber = 100;

    private NativeArray<Entity> entityArray;

    // 字段（序列化字段）
    [SerializeField]
    private Mesh _Mesh;
    [SerializeField]
    private Material _Material;

    private void Start() {
        // 创建实体管理器
        EntityManager entityMgr = World.Active.EntityManager;

        // 创建 “实体原型类型”
        EntityArchetype entityAr = entityMgr.CreateArchetype(
            typeof(Times),         //时间组件
            typeof(Moving),        //自定义移动组件
            typeof(Translation),   //系统移动组件
            typeof(RenderMesh),    //渲染组件
            typeof(LocalToWorld)   //渲染支持组件
        );

        // 建立本地集合类型
        entityArray = new NativeArray<Entity>(PlaneCreateNumber, Allocator.Persistent);

        // 创建实体，将"实体原型类型"和"本地集合类型"结合起来
        entityMgr.CreateEntity(entityAr, entityArray);

        for (int i = 0; i < entityArray.Length; i++)
        {
            entityMgr.SetComponentData(entityArray[i], new Times { timeByComponet = 1F });
            entityMgr.SetComponentData(entityArray[i], new Moving { MoveSpeed = UnityEngine.Random.Range(1, 5) });
            entityMgr.SetComponentData(entityArray[i], new Translation { Value = new Unity.Mathematics.float3(UnityEngine.Random.Range(-8, 8), UnityEngine.Random.Range(-5, 5), 0)});

            entityMgr.SetSharedComponentData(entityArray[i], new RenderMesh() {
                material = _Material,
                mesh = _Mesh
            });
        }
    }

    private void OnDestroy() {
        if (entityArray!=null) {
            entityArray.Dispose();
        }
    }

}
