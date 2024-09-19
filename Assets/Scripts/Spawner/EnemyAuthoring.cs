using Unity.Entities;
using UnityEngine;

public class EnemyAuthoring : MonoBehaviour
{
    public float MoveSpeed;

    class EnemyAuthoringBaker : Baker<EnemyAuthoring>
    {

        public override void Bake(EnemyAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);

            AddComponent<EnemyTag>(entity);

            AddComponent(entity, new EnemyMoveSpeed
            {
                Value = authoring.MoveSpeed,
            });
        }
    }
}


public struct EnemyMoveSpeed : IComponentData
{
    public float Value;
}

public struct EnemyTag : IComponentData
{

}