using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Spawner : CustomBehaviour
{

    private float x, y, z;

    [SerializeField]
    private int maxCountWood;

    [SerializeField]
    private int totalWood;

    [SerializeField]
    private float creatTime;
    [SerializeField]
    private Transform startArea;

    [SerializeField]
    private Transform goPosition;
    [Header("Distance range of wood array")]
    [SerializeField]
    private float xOffSet, yOffSet, zOffSet;
    private void Start()
    {
        InvokeRepeating(nameof(CreateWood), 1f, creatTime);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateFinished();
        }
    }
    public void CreateWood()
    {
        if (totalWood >= maxCountWood)
        {
            return;
        }
        GameObject currentWood = null;

        currentWood = GameManager.objectPool.GetObject("Wood", startArea.position);

        currentWood.transform.DOMove(goPosition.position, 0.3f).SetEase(Ease.OutBack);

        totalWood++;

        AddThreeByThreeMatrix();

        goPosition.localPosition = new Vector3(x, y, z);
    }

    public void AddThreeByThreeMatrix()
    {
        if (totalWood % 3 == 0)
        {
            y += yOffSet;
            x = 0;
        }

        else x += xOffSet;

        if (totalWood % 9 == 0)
        {
            z += zOffSet;
            x = 0;
            y = 0;
        }
    }
    public void ExtractionWood()
    {
        if (totalWood % 3 == 0)
        {
            y -= yOffSet;
            x = 0;
        }

        else x -= xOffSet;

        if (totalWood % 9 == 0)
        {
            z -= zOffSet;
            x = 0;
            y = 0;
        }
    }
    public void CreateFinished()
    {
        ///////En baþa Dön 
        totalWood = 0;
        x = 0;
        y = 0;
        z = 0;
        goPosition.localPosition = new Vector3(x, y, z);
    }
}
