using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;

public class Analytics : MonoBehaviour
{
    // Calls the start of the game analytics
    void Start() {
        GameAnalytics.Initialize();
    }
}
