using UnityEngine;
using System.Collections;

public class Clock : MonoBehaviour
{
    public int hz;
    private float tickRate;
    private Core core;

    public void StartTicking()
    {
        StartCoroutine(Tick());
    }

    private IEnumerator Tick()
    {
        while (true)
        {
            core.Tick();

            yield return new WaitForSeconds(tickRate);
        }
    }

    public void Init(Core core, int hz)
    {
        this.hz = hz;
        this.core = core;
        this.tickRate = 1f / hz;
    }
    
	
}
