using UnityEngine;
using BlockCity.Visual;

namespace BlockCity.Visual
{
	public class InterconnectVisual : ConnectorVisual
	{
		void Start ()
		{
			LoadPrefab("Interconnect");
		}
	}
}

