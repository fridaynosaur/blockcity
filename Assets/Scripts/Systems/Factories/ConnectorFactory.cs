using System;
using UnityEngine;

namespace BlockCity {
	public class ConnectorFactory
	{
		private CoreFactory coreFactory;

		public ConnectorFactory (CoreFactory coreFactory)
		{
			this.coreFactory = coreFactory;
		}

		public void CreateConnectorFromTo(Vector3 position1, Vector3 position2) {
			GameObject connectorObject = new GameObject ();
		}
	}
}