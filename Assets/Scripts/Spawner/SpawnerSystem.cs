using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public partial struct SpawnerSystem : ISystem
{
    public void OnCreate(ref SystemState state)
    {

    }

    public void OnDestroy(ref SystemState state) 
    {
    
    }

    public void OnUpdate(ref SystemState state) 
    {
        foreach(RefRW<Spawner> spawner in SystemAPI.Query<RefRW<Spawner>>())
        {
            if (spawner.ValueRO.NextSpawnTime < SystemAPI.Time.ElapsedTime)
            {
                Entity newEntity = state.EntityManager.Instantiate(spawner.ValueRO.Prefab);
                float3 position = new float3(UnityEngine.Random.Range(-5f, 5f), 5f, 0);
                state.EntityManager.SetComponentData(newEntity, LocalTransform.FromPosition(position));
                spawner.ValueRW.NextSpawnTime = (float)SystemAPI.Time.ElapsedTime + spawner.ValueRO.SpawnRate;
            }
        }
    }

}