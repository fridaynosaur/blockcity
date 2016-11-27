using UnityEngine;
using System.Collections;

namespace BlockCity {
		
	public class CoreFactory
	{
	    public IdFactory IdFactory { get; private set; }
	    public BlockFactory BlockFactory { get; private set; }
		public RoadFactory RoadFactory { get; private set; }

	    public CoreFactory(Core core)
	    {
	        IdFactory = new IdFactory();
	        BlockFactory = new BlockFactory(core);
	        RoadFactory = new RoadFactory (core);
	    }
	}    
}
