using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum symbols
{
    one,two, three, four, five, six, seven, eight, nine, ten
}

public class SymbolPool : MonoBehaviour
{
    int slices;
    public List<symbols> s;
    void Start()
    {
        int S = Enum.GetValues(typeof(symbols)).Length;
        s = new List<symbols>();
        slices = GetComponentInChildren<Reels>().slices;
        LoadPool();
    }

    public void LoadPool()
    {
        int[] arr = {
            1,    1,    1,         1,   1,   1,1,1,1,1};
        int S = Enum.GetNames(typeof(symbols)).Length;
        for (int i = 0; i < S; i++)
        {
            for (int j = 0; j < arr[i]; j++)
            {
               s.Add((symbols)i);
            }
        }
    }

    void Update()
    {
        
    }

    public int PopSymbol()
    {
        if (s.Count < 1)
        {
            print("Your tokenpool is left giving random token");
            return UnityEngine.Random.Range(0, Enum.GetNames(typeof(symbols)).Length);
        }
        int r = UnityEngine.Random.Range(0, s.Count);
        int tmp = (int) s[r];
        s.RemoveAt(r);
        return tmp;
    }
}
