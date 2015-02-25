using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class LevelCap
{
    private static List<float> list = new List<float>();

    public static void LoadCap()
    {
        list.Add(250f);
        list.Add(500f);
        list.Add(800f);
        list.Add(1300f);
        list.Add(2000f);
    }
    public static float GetExpLevel (int i)
    {
       
        return list[i];
    }
}
