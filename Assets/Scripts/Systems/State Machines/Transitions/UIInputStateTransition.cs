using UnityEngine;
using System.Collections;


namespace BlockCity.System
{
	public class UIInputStateTransition
	{
		private UIInputState state;
		private UIInputStateAction command;

		public UIInputStateTransition(UIInputState state, UIInputStateAction command)
		{
			this.state = state;
			this.command = command;
		}

	}
}