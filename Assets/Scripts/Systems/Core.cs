using UnityEngine;
using System.Collections;

public class Core : MonoBehaviour
{
    public VisualHolder visualCreator;

    public Game Game { get; private set; }
    public CoreFactory CoreFactory { get; private set; }

    void Awake()
    {
        if (visualCreator == null)
        {
            throw new MissingComponentException();
        }

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
}
