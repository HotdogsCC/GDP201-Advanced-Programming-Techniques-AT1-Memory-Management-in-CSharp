using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class BaseMonoBehaviour : MonoBehaviour
{
    // This is to simulate a large object
    int[] memory_payload;

    void Start()
    {
        memory_payload = new int[10000000];
    }
}
