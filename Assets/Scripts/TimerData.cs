using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TimerData
{
    private static float startTime;
    private static float maxTime = 5 * 60f;

    public static void StartTimer()
    {
        startTime = Time.time;
    }

    public static float TimeLeft()
    {
        float timeSinceStart = Time.time - startTime;
        return maxTime - timeSinceStart;
    }
}
