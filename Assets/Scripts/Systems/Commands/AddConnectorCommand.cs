using UnityEngine;
using System.Collections;
using BlockCity;

namespace BlockCity.Systems {
	
	public class AddConnectorCommand : Command {
		private Vector3 position;
		private Vector3 size;
		private string type;

		public AddConnectorCommand(Vector3 position, Vector3 size, string type)
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

			//Interconnect connect = core.CoreFactory.ConnectorFactory.CreateBlock (position, size, type);
			//core.Grid.AddBlock(block, position);
			//core.visuals.AddBlock(block);
		}
	}
}