using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;

public class Analytics : MonoBehaviour
{
    void Awake() {
        GameAnalytics.Initialize();
    }
}
