using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public GameObject SettingsButton;
    public void PauseButtonPress() {
        if (GameController.instance.IsPaused()) {
            GameController.instance.UnPause();
        } else {
            GameController.instance.Pause();
        }
    }
}
