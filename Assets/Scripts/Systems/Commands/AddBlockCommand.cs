using UnityEngine;
using System.Collections;
using System;
using BlockCity.Core;

public class AddBlockCommand : Command
{
    private Vector3 position;
    private Vector3 size;
    private string type;

    public AddBlockCommand(Vector3 position, Vector3 size, string type)
    {
        this.position = position;
        this.size = size;
        this.type = type;
    }

    public override void Execute(Core core)
    {
        Debug.Log("Command Execute: " + this);
        Debug.Log("Command Execute: pos: " + position);

        if (!core.Grid.IsFree(position))
        {
            return;
        }

        Block block = core.CoreFactory.BlockFactory.CreateBlock(position, size, type);
        core.Grid.AddBlock(block, position);

        core.visuals.AddBlock(block);
    }


}
