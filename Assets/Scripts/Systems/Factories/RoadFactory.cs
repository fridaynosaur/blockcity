using System;
using UnityEngine;
using System.Collections.Generic;
using BlockCity.Visual;

namespace BlockCity {
	public class RoadFactory
	{
		private Core core;
		private Queue<Vector3> roadQueue = new Queue<Vector3>()	;

		public RoadFactory (Core core)
		{
			this.core = core;
		}

		public RoadState AddRoadPoint(Vector3 position) {
			roadQueue.Enqueue (position);

			RoadState state = GetRoadStateFromQueueSize ();

			if (state == RoadState.FINISHED) {
				CreateRoadFromTo (roadQueue.Dequeue (), roadQueue.Dequeue ());
				return RoadState.FINISHED;
			}

			return state;
		}

		public void CreateRoadFromTo(Vector3 start, Vector3 end) {
			GameObject roadGameObject = new GameObject("Road");
			Road road = roadGameObject.AddComponent<Road> ();

			road.Init(core.CoreFactory.IdFactory.CreateId(), start, end, Vector3.one);

			RoadVisual roadVisual = roadGameObject.AddComponent<RoadVisual> ();
			roadVisual.Road = road;
			roadVisual.PrefabName = "Infrastructure/Road";
			roadVisual.Mesh = road.CreateMesh ();

			core.Grid.AddBlock(road, start);
			core.Visuals.AddBlock (road);

		}

		private RoadState GetRoadStateFromQueueSize() {
			switch (roadQueue.Count) {
			case 0:
				return RoadState.EMPTY;
			case 1:
				return RoadState.START;
			case 2: 
			default:
				return RoadState.FINISHED;

			}
		}
			
	}
}