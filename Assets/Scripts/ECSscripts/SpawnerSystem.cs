using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

public class SpawnerSystem : JobComponentSystem
{
    EndSimulationEntityCommandBufferSystem EntityCommandBufferSystem;

    protected override void OnCreateManager()
    {
        EntityCommandBufferSystem = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
    }

    [System.Obsolete] 
    struct SpawnJob: IJobProcessComponentDataWithEntity<Spawner, LocalToWorld>
    {
        public EntityCommandBuffer CommandBuffer;
        public void Execute(Entity entity, int index, [ReadOnly] ref Spawner spawner, [ReadOnly] ref LocalToWorld location)
        {
            for (int x = 0; x < spawner.ECSRows; x++)
            {
                for (int z = 0; z < spawner.ECSColumns; z++)
                {
                    var instance = CommandBuffer.Instantiate(spawner.Prefab);
                    var position = math.transform(location.Value,
                        new float3(x, noise.cnoise(new float2(x, z) * 0.21f) * 3,
                        z));
                    CommandBuffer.SetComponent(instance, new Translation { Value = position });
                }
            }
            CommandBuffer.DestroyEntity(entity);
        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var job = new SpawnJob
        {
            CommandBuffer = EntityCommandBufferSystem.CreateCommandBuffer()
        }.ScheduleSingle(this, inputDeps);

        EntityCommandBufferSystem.AddJobHandleForProducer(job);
        return job;
    }
}
