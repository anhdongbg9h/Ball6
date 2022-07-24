using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common
{
    public static void Warning(bool condition, object message)
    {
        if (!condition)
        {
            Debug.LogWarning(message);
        }
    }
}
