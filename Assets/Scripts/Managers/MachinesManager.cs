using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachinesManager : CustomBehaviour
{
    public List<Spawner> machines;
    public override void Initialize(GameManager gameManager)
    {
        base.Initialize(gameManager);
        FindMachines();
        foreach (var item in machines)
        {
            item.Initialize(gameManager);
        }
    }
    public void FindMachines()
    {
        Spawner spawner = GameObject.FindObjectOfType<Spawner>();
        machines.Add(spawner);
    }
}
