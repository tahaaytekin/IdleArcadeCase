using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : CustomBehaviour
{
    public EventManager eventManager;
    public InputManager inputManager;
    public ObjectPool objectPool;
    public MachinesManager machinesManager;

    private void Start()
    {
        eventManager.Initialize(this);

        inputManager.Initialize(this);

        objectPool.Initialize(this);

        machinesManager.Initialize(this);

    }
}
