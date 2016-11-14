using UnityEngine;
using System.Collections;

public class Core : MonoBehaviour
{
    public Game Game { get; private set; }
    public CoreFactory CoreFactory { get; private set; }

    void Start()
    {
        Init();
    }
    
    public void Init()
    {
        Game = new Game();
        CoreFactory = new CoreFactory();
    }

    public void SendCommand(Command command)
    {
        command.Execute(this);
    }

    public void Kuku()
    {

    }



}
