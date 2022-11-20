using UnityEngine;
using Leopotam.EcsLite;
using Voody.UniLeo.Lite;
using Leopotam.EcsLite.ExtendedSystems;
public sealed class EcsGameStartUp : MonoBehaviour
{
    /// <summary>
    /// Contain all entities
    /// </summary>
    private EcsWorld world;
    /// <summary>
    /// Contain all sytems
    /// </summary>
    private EcsSystems _systems;

    private void Start()
    {
        world = new EcsWorld();
        _systems = new EcsSystems(world);

        _systems.ConvertScene();

        AddInjections();
        AddSystems();
        AddOneFrames();
    }
    private void Update()
    {
        _systems.Run();
    }
    private void AddInjections()
    {

    }
    private void AddSystems()
    {
        _systems
            .Add(new CursorLockSystem())
            .Add(new PlayerSendJumpEvent()) // work
            .Add(new GroundCheckSystem()) // work
            .Add(new PlayerInputSystem())
            .Add(new PlayerMouseInputSystem())
            .Add(new GravitySystem())
            .Add(new PlayerInitCharacteristicsSystem())
            .Add(new PlayerJumpSystem())
            .Add(new MovementSystem())
            .Add(new TestSystem())
            .DelHere<JumpEvent>()
            .Init();
        Debug.Log("systems added");
    }   
    private void AddOneFrames()
    {

    }
    private void OnDestroy()
    {
        if (_systems == null) return;
        _systems.Destroy();
        _systems = null;
        world.Destroy();
        world = null;
    }
}
