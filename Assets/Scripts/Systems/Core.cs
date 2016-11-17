using UnityEngine;
using System.Collections;
using BlockCity.Core;

public class Core : MonoBehaviour
{
    public Visuals visuals;

    public Game Game { get; private set; }
    public CoreFactory CoreFactory { get; private set; }
    public Grid2d Grid { get; private set; }
    

    void Awake()
    {
        if (visuals == null)
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
