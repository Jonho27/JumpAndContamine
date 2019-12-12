using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PutLevels : MonoBehaviour
{
    private void Start()
    {
        DestroyLevels();
        GenerateLevels();
    }

    public static void GenerateLevels()
    {

        
        GameObject[] levels = new GameObject[16];

        levels[0] = Resources.Load("prefabs/JORGE 1") as GameObject;
        levels[1] = Resources.Load("prefabs/JORGE 2") as GameObject;
        levels[2] = Resources.Load("prefabs/JORGE 3") as GameObject;
        levels[3] = Resources.Load("prefabs/JORGE 4") as GameObject;
        levels[4] = Resources.Load("prefabs/JON 1") as GameObject;
        levels[5] = Resources.Load("prefabs/JON 2") as GameObject;
        levels[6] = Resources.Load("prefabs/JON 3") as GameObject;
        levels[7] = Resources.Load("prefabs/JON 4") as GameObject;
        levels[8] = Resources.Load("prefabs/FRAN 1") as GameObject;
        levels[9] = Resources.Load("prefabs/FRAN 2") as GameObject;
        levels[10] = Resources.Load("prefabs/PAU 1") as GameObject;
        levels[11] = Resources.Load("prefabs/PAU 2") as GameObject;
        levels[12] = Resources.Load("prefabs/PAU 3") as GameObject;
        levels[13] = Resources.Load("prefabs/PAU 4") as GameObject;
        levels[14] = Resources.Load("prefabs/FRAN 3") as GameObject;
        levels[15] = Resources.Load("prefabs/FRAN 4") as GameObject;

        for (int i = 0; i < 100; i++)
        {

            Instantiate(levels[(int)Random.Range(0, 15)], new Vector3(0f, i * 60f , 0f), Quaternion.identity);
        }

    }

    
    public static void DestroyLevels()
    {


        GameObject[] destroyLevels = GameObject.FindGameObjectsWithTag("levelPrefab");

        
        for (int i = 0; i < destroyLevels.Length; i++)
        {

            DestroyImmediate(destroyLevels[i]);
        }

    }
}
