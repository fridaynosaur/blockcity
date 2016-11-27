using UnityEngine;
using System.Collections;
using BlockCity;

namespace BlockCity {
	
	public class AddRoadCommand : Command {
		private Vector3 position;
		private Vector3 size;
		private string type;

		public AddRoadCommand(Vector3 position, Vector3 size, string type)
		{
			this.position = position;
			this.size = size;
			this.type = type;
		}

		public override void Execute(Core core)
		{
			Debug.Log("Command Execute: " + this.ToString());

			if (!core.Grid.IsFree(position))
			{
				return;
			}

			RoadState roadState = core.CoreFactory.RoadFactory.AddRoadPoint (position);

			Debug.Log ("Road building state: " + roadState.ToString ());
		}
	}
}