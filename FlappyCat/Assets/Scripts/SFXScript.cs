using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXScript : MonoBehaviour
{
    private float EffectVol = 0.5f;
    private float VolChange = 0.1f;
    private bool ended = false;
    public AudioClip DieClip;

    public AudioSource EffectSource;

    // Start is called before the first frame update
    void Start()
    {
        EffectSource.volume = EffectVol;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameController.instance.GameOver && !ended) {
            EffectSource.clip = DieClip;
            EffectSource.PlayOneShot(DieClip);
            ended = true;
        } else if (GameController.instance.IsStarted()) {
            // checks for sound events;
        }
    }

    void IncreaseVol(){
        if(EffectVol < 1) {
            EffectVol += VolChange;
        } else {
             EffectVol = 1;
        }
       EffectSource.volume = EffectVol;
    }

    void DecreaseVol(){
        if(EffectVol > 0) {
            EffectVol -= VolChange;
        } else {
             EffectVol = 0;
        }
       EffectSource.volume = EffectVol;
    }

}
