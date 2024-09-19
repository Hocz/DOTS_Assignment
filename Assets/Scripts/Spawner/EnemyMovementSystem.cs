using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

public partial struct EnemyMovementSystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        float deltaTime = SystemAPI.Time.DeltaTime;

        foreach (var (transform, moveSpeed) in SystemAPI.Query<RefRW<LocalTransform>, EnemyMoveSpeed>())
        {
            transform.ValueRW.Position -= transform.ValueRO.Up() * moveSpeed.Value * deltaTime;
        }
    }
}