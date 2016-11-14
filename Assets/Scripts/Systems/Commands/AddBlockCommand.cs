using UnityEngine;
using System.Collections;
using System;

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
        core.CoreFactory.BlockFactory.CreateBlock(position, size);
    }


}
