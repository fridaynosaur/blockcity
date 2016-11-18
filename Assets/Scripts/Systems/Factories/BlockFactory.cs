using UnityEngine;
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

    public Block CreateBlock(Vector3 position, Vector3 size, string type)
    {
        GameObject blockGameObject = new GameObject();

        Block block = blockGameObject.AddComponent<Block>();
        block.Init(coreFactory.IdFactory.CreateId(), position, size);

        BlockVisual visual = blockGameObject.AddComponent<BlockVisual>();
        visual.PrefabName = GetPrefabName(type);
        visual.Block = block;

        //blockGameObject.AddComponent<BuildingVisual>();
        
        return block;
    }

    private string GetPrefabName(string type)
    {
        switch(type)
        {
            case BuildingTypes.Road:            return "Road";
            case BuildingTypes.ElectricPlant:   return "ElectricPlant";
            case BuildingTypes.House:           return "House";

            default:
                Debug.LogWarning("Unknown building type: " + type);
                break;
        }

        return null;
    }
    
    
}
