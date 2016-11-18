using UnityEngine;
using System.Collections;

public class CoreFactory
{
    public IdFactory IdFactory { get; private set; }
    public BlockFactory BlockFactory { get; private set; }

    public CoreFactory(Core core)
    {
        IdFactory = new IdFactory();
        BlockFactory = new BlockFactory(core);
    }
    
}
