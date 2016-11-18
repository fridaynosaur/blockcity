using UnityEngine;
using System.Collections;

namespace BlockCity {
	
	public class IdFactory
	{
		private int id = 0;

		public IdFactory()
		{

		}
		
		public int CreateId()
		{
			return ++id;
		}
	}
}
