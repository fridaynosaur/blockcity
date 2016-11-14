using UnityEngine;
using System.Collections;

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
        
        
        
        return blockGameObject;
    }
}
