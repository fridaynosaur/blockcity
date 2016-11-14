using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace BlockCity.System {
		
	public class UIInputStateMachine : MonoBehaviour {
		private UIInputState state;
		private UIInputStateAction command;
		private Dictionary<UIInputStateTransition, UIInputState> transitions;

		void Start () {
			Init();
		}

		private void Init() {
			this.state = UIInputState.IDLE;

			transitions = new Dictionary<UIInputStateTransition, UIInputState> {
				{ new UIInputStateTransition (UIInputState.IDLE, UIInputStateAction.BEGIN), UIInputState.WAITING_FOR_USER },
				{ new UIInputStateTransition (UIInputState.WAITING_FOR_USER, UIInputStateAction.END), UIInputState.IDLE }
			};

		}

		public UIInputState GetNextTransition(UIInputStateAction action) {
			UIInputStateTransition transition = new UIInputStateTransition (state, action);

			UIInputState nextState;

			if (!transitions.TryGetValue(transition, out nextState))
				throw new Exception("Invalid transition: " + state + " -> " + action);
			return nextState;
		}

		public UIInputState ProcessTransition(UIInputStateAction command) {
			state = GetNextTransition (command);
			return state;
		}

	}
}