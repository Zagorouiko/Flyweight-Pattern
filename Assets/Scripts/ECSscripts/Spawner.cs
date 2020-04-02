using Unity.Entities;

public struct Spawner : IComponentData
{
    public Entity Prefab;
    public int ECSRows;
    public int ECSColumns;
}
