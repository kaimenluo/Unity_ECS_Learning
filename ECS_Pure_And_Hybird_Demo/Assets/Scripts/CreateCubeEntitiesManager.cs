/***
 *
 * Hybrid ECS演示项目
 *
 * Title: 创建海量Cube 实体管理器
 *
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class CreateCubeEntitiesManager : MonoBehaviour
{
    // 游戏对象预设
    public GameObject goPrefab;

    // 对象克隆数量
    public int XNum = 10;
    public int YNum = 10;

    // 实体对象
    Entity entity;

    // 实体对象管理器
    EntityManager entityMgr;

    // Start is called before the first frame update
    void Start() {
        if (goPrefab == null) {
            Debug.Log(GetType() + "/Start()/游戏预设没有指定,请检查!");
        }

        //游戏对象转成实体
        entity = GameObjectConversionUtility.ConvertGameObjectHierarchy(goPrefab, World.Active);

        //得到实体管理器
        entityMgr = World.Active.EntityManager;


        //按照指定的数量，克隆大量实体, 且指定分布位置
        for (int x = 0; x < XNum; x++) {
            for (int z = 0; z < YNum; z++) {
                Entity entityClone = entityMgr.Instantiate(entity);
                Vector3 position = transform.TransformPoint(new float3(x - XNum/2, noise.cnoise(new float2(x,z)*0.21F), z-YNum /2));
                //Vector3 position = transform.TransformPoint(new float3(x,0,z));

                // 实体管理器设置其中的组件参数
                entityMgr.SetComponentData(entityClone, new Translation() { Value = position});

                //把定义的组件加入实体管理器里面
                //entityMgr.AddComponentData(entityClone, new Movement() { MoveSpeed = 1F });
                entityMgr.AddComponentData(entityClone, new Movement() { MoveSpeed = UnityEngine.Random.Range(1,5)});
            }
        }


    }

  
}
