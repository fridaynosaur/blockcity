using UnityEngine;
using System.Collections;
using System;
using BlockCity;

namespace BlockCity {
		
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
			Debug.Log("Command Execute: " + this.ToString() + " of type " + type);
	        
	        if (!core.Grid.IsFree(position))
	        {
	            return;
	        }

	        Block block = core.CoreFactory.BlockFactory.CreateBlock(position, size, type);

			// todo: proc se tohle dela v commandu? 
			// Nemel by to spravovat nejakej jinej objekt? Co kdyz pak budeme potrebovat referenci z visual na nas "core" objekt?
	        core.Grid.AddBlock(block, position);
			core.Visuals.AddBlock(block);
	    }


	}
}