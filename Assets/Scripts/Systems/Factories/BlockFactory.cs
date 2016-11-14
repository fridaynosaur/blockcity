﻿using UnityEngine;
using System.Collections;
using BlockCity.Core;
using BlockCity.Visual;

public class BlockFactory
{
    private CoreFactory coreFactory;

    public BlockFactory(CoreFactory coreFactory)
    {
        this.coreFactory = coreFactory;
    }

    public GameObject CreateBlock(Vector3 position, Vector3 size)
    {
        GameObject blockGameObject = new GameObject();

        Block block = blockGameObject.AddComponent<Block>();
        block.Init(coreFactory.IdFactory.CreateId(), position, size);

        BlockVisual visual = blockGameObject.AddComponent<BlockVisual>();
        visual.Block = block;

        blockGameObject.AddComponent<BuildingVisual>();
        
        return blockGameObject;
    }
}
