using UnityEngine;
using System.Collections.Generic;
using System;

public class Inventory
{
    private Dictionary<string, int> itemIntances;

    private List<string> relativeItems = new List<string>() { Currency.Power };
    

    public Inventory()
    {
        itemIntances = new Dictionary<string, int>();

        foreach (var relative in relativeItems)
        {
            itemIntances[relative] = 0;
        }
    }

    public void Tick()
    {
        ResetRelative();
    }

    public void AddQuantityRelative(string item, int quantity)
    {
        if (!itemIntances.ContainsKey(item))
        {
            itemIntances.Add(item, quantity);
        }
        else
        {
            itemIntances[item] += quantity;
        }

        Debug.Log("Inventory:: AddQuantity: Item: " + item + " = " + quantity + "; total = " + itemIntances[item]);
    }

    public void AddQuantity(string item, int quantity)
    {
        if (!itemIntances.ContainsKey(item))
        {
            itemIntances.Add(item, quantity);
        }
        else
        {
            itemIntances[item] += quantity;
        }

        Debug.Log("Inventory:: AddQuantity: Item: " + item + " = " + quantity + "; total = " + itemIntances[item]);
    }
    
    public int GetQuantity(string item)
    {
        int quantity;

        itemIntances.TryGetValue(item, out quantity);
        
        return quantity;
    }

    public bool HasEnough(string item, int quantity)
    {
        int current;

        itemIntances.TryGetValue(item, out current);
        
        return current >= quantity;
    }

    public void ResetRelative()
    {
        foreach (var relative in relativeItems)
        {
            Debug.Log("Relative: " + relative + " = " + itemIntances[relative]);

            itemIntances[relative] = 0;
        }
    }
}
