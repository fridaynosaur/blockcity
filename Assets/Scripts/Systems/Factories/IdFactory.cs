using UnityEngine;
using System.Collections;

public class IdFactory
{
    private int id = 0;
    private CoreFactory coreFactory;

    public IdFactory(CoreFactory coreFactory)
    {
        this.coreFactory = coreFactory;
    }
    
	public int CreateId()
    {
        return ++id;
    }
}
