using UnityEngine;
using System.Collections;
using System;
using BlockCity.Core;

public class AddBlockCommand : Command
{
    private Vector3 position;
    private Vector3 size;

    public AddBlockCommand(Vector3 position, Vector3 size)
    {
        this.position = position;
        this.size = size;
    }

    public override void Execute(Core core)
    {
        Debug.Log("Command Execute: " + this);
        Debug.Log("Command Execute: pos: " + position);

        if (!core.Grid.IsFree(position))
        {
            return;
        }

        Block block = core.CoreFactory.BlockFactory.CreateBlock(position, size);
        core.Grid.AddBlock(block, position);

        core.visuals.AddBlock(block);
    }


}
