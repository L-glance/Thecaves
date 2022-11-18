﻿using Leopotam.EcsLite;
using UnityEngine;

sealed class MovementSystem : IEcsRunSystem
{
    public void Run(EcsSystems system)
    {
        var filter = system.GetWorld().Filter<PlayerTag>().Inc<MovableComponent>().Inc<ModelComponent>().Inc<TransformComponent>().End();
        
        var movablePool = system.GetWorld().GetPool<MovableComponent>();
        var modelPool = system.GetWorld().GetPool<ModelComponent>();
        var directionPool = system.GetWorld().GetPool<TransformComponent>();

        foreach (var entity in filter )
        {
            ref var movableComponent = ref movablePool.Get(entity);
            ref var modelComponent = ref modelPool.Get(entity);
            ref var directionComponent = ref directionPool.Get(entity);

            ref var direction = ref directionComponent.position;
            ref var transform = ref modelComponent.modelTransform;

            var characterController = movableComponent.characterController;

            var rawDirection = direction.x * transform.right + direction.z * transform.forward;

            var speed = movableComponent.speed;
            Debug.Log(speed);
            characterController.Move(speed * rawDirection * Time.deltaTime);

        }
    }
}
