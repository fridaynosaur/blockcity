using UnityEngine;
using System.Collections;

public class CoreFactory
{
    public IdFactory IdFactory { get; private set; }
    public BlockFactory BlockFactory { get; private set; }

    public CoreFactory()
    {
        IdFactory = new IdFactory(this);
        BlockFactory = new BlockFactory(this);
    }
    
}
