using UnityEngine;
using System.Collections;
using BlockCity.Core;
using System;

public class Core : MonoBehaviour
{
    public Visuals visuals;

    public Clock Clock { get; private set; }
    public Game Game { get; private set; }
    public CoreFactory CoreFactory { get; private set; }
    public Grid2d Grid { get; private set; }
    public Inventory Inventory { get; private set; }
    

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
        CoreFactory = new CoreFactory(this);
        Grid = new Grid2d(500);
        Inventory = new Inventory();

        Clock = gameObject.AddComponent<Clock>();
        Clock.Init(this, 1);

        StartGame();
    }

    public void StartGame()
    {
        Clock.StartTicking();
    }

    public void SendCommand(Command command)
    {
        command.Execute(this);
    }

    internal void Tick()
    {
        Inventory.Tick();
    }
}
