﻿using Leopotam.EcsLite;
using UnityEngine;

/// <summary>
/// System for processing character movement
/// </summary>
sealed class PlayerMovementSystem : IEcsRunSystem
{
    public void Run(EcsSystems system)
    {
        var filter = system.GetWorld().Filter<PlayerTag>().End();
        var movablePool = system.GetWorld().GetPool<MovableComponent>();
        var modelPool = system.GetWorld().GetPool<ModelComponent>();
        var directionPool = system.GetWorld().GetPool<DirectionComponent>();
        var sprintPool = system.GetWorld().GetPool<SprintComponent>();
        foreach (var entity in filter)
        {
            ref var movableComponent = ref movablePool.Get(entity);
            if (!CharacterAbilities.canCharacterMove) continue;

            ref var modelComponent = ref modelPool.Get(entity);
            ref var directionComponent = ref directionPool.Get(entity);
            ref var sprintComponent = ref sprintPool.Get(entity);

            ref var direction = ref directionComponent.direction;
            ref var transform = ref modelComponent.modelTransform;

            var characterController = movableComponent.characterController;

            var rawDirection = direction.x * transform.right + direction.z * transform.forward;
            var accurateDirection = Vector3.ClampMagnitude(rawDirection, 1);

            // change speed 
            var speed = sprintComponent.isRunning ? sprintComponent.accelerationFactor * movableComponent.defaultSpeed : movableComponent.defaultSpeed;

            var velocity = movableComponent.velocity;

            characterController.Move(speed * Time.deltaTime * accurateDirection);
            characterController.Move(velocity * Time.deltaTime);
        }
    }
}
