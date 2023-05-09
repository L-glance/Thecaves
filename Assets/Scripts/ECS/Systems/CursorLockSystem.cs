using Leopotam.EcsLite;
using UnityEngine;

/// <summary>
/// System for blocking and changing the visibility of the cursor depending on the state of the player's inventory
/// </summary>
public sealed class CursorLockSystem : IEcsRunSystem
{
    public void Run(EcsSystems system)
    {
        var filter = system.GetWorld().Filter<PlayerTag>().Inc<PlayerInventoryComponent>().End();
        foreach (var entity in filter)
        {
            ref var inventory = ref system.GetWorld().GetPool<PlayerInventoryComponent>().Get(entity);
            //if (inventory.isInventoryOppened)
            //{
            //    Cursor.lockState = CursorLockMode.None;
            //    Cursor.visible = true;
            //}
            //else
            //{
            //    Cursor.lockState = CursorLockMode.Locked;
            //    Cursor.visible = false;
            //}
        }
    }
}
