using UnityEngine;
using System.Collections;
using BlockCity;
using BlockCity.Visual;

public class BlockFactory
{
    private Core core;

    public BlockFactory(Core core)
    {
        this.core = core;
    }

    public Block CreateBlock(Vector3 position, Vector3 size, string type)
    {
        GameObject blockGameObject = new GameObject();

        Block block = blockGameObject.AddComponent<Block>();
        block.Init(core.CoreFactory.IdFactory.CreateId(), position, size);

        CreateComponentsByType(type, block);

        BlockVisual visual = blockGameObject.AddComponent<BlockVisual>();
        visual.PrefabName = GetPrefabName(type);
        visual.Block = block;
        
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

    private void CreateComponentsByType(string type, Block block)
    {
        switch(type)
        {
            case BuildingTypes.Road:
                break;

            case BuildingTypes.ElectricPlant:
                CreateElectricPlant(block);
                break;

            case BuildingTypes.House:
                CreateHouse(block);
                break;
        }
    }

    private void CreateElectricPlant(Block block)
    {
        var generator = block.gameObject.AddComponent<Generator>();
        generator.Init(core.Inventory, Currency.Power, 5, 1);
    }

    private void CreateHouse(Block block)
    {
        var generator = block.gameObject.AddComponent<Generator>();
        generator.Init(core.Inventory, Currency.Power, -1, 1);
    }


}
