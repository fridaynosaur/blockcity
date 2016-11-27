using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour
{
    public string item;
    public int rate;
    public int interval;

    private float lastUpdateTime;
    private Inventory inventory;

	
    public void Init(Inventory inventory, string item, int rate, int interval)
    {
        this.inventory = inventory;
        this.item = item;
        this.rate = rate;
        this.interval = interval;
    }

	void Start ()
    {
	    if (inventory == null)
        {
            throw new MissingReferenceException();
        }
	}
	
	void Update ()
    {
	    if (Time.time - lastUpdateTime > interval)
        {
            lastUpdateTime = Time.time;

            Generate();
        }
	}

    private void Generate()
    {
		// spammer
        //Debug.Log("Generator:: Generate: " + item + " rate: " + rate);

        inventory.AddQuantity(item, rate);
    }
    
}
