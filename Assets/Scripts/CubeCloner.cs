using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCloner : MonoBehaviour
{
    [SerializeField] public GameObject cubeOriginal;
    [SerializeField] public GameObject cubeContainer;
    [SerializeField] private int zAxisCubeCount;
    [SerializeField] private int xAxisCubeCount;
    [SerializeField] private int xPositionOffSet;

    private void Start()
    {
        CreateCubes();
    }

    private void CreateCubes()
    {
        for (int k = 0; k < xAxisCubeCount; k++)
        {
            for (int i = 0; i < zAxisCubeCount; i++)
            {
                var cubeClone = Instantiate(cubeOriginal, new Vector3(xPositionOffSet + k, cubeOriginal.transform.position.y, i)
                    ,cubeOriginal.transform.rotation, cubeContainer.transform);
                
                cubeClone.name = "CubeClone" + ((k * i) + 1);
            }   
        }
    }
    
}
