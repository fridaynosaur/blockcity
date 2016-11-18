using UnityEngine;
using System.Collections;

namespace BlockCity {
	
	public class Core : MonoBehaviour
	{
		public Visuals Visuals { get; private set; }

	    public Game Game { get; private set; }
	    public CoreFactory CoreFactory { get; private set; }
	    public Grid2d Grid { get; private set; }
	    

	    void Awake()
	    {
	        if (Visuals == null)
	        {
	            throw new MissingComponentException();
	        }

	        Init();
	    }
	    
	    public void Init()
	    {
	        Game = new Game();
	        CoreFactory = new CoreFactory();
	        Grid = new Grid2d(500);
	    }

	    public void SendCommand(Command command)
	    {
	        command.Execute(this);
	    }
	}
}