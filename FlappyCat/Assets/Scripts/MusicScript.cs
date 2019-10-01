using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    private float MusicVol = 0.1f;
    private float VolChange = 0.1f;
    public AudioClip MusicClip;

    public AudioSource MusicSource;

    // Start is called before the first frame update
    void Start()
    {
        MusicSource.clip = MusicClip;
        MusicSource.Play();
        MusicSource.volume = MusicVol;
    }

    // Update is called once per frame
    void Update()
    {
        if(!MusicSource.isPlaying) {
            MusicSource.Play();
        }
        if(GameController.instance.GameOver) {
            MusicSource.Stop();
        }
    }

    void IncreaseVol(){
        if(MusicVol < 1) {
            MusicVol += VolChange;
        } else {
             MusicVol = 1;
        }
       MusicSource.volume = MusicVol;
    }

    void DecreaseVol(){
        if(MusicVol > 0) {
            MusicVol -= VolChange;
        } else {
             MusicVol = 0;
        }
       MusicSource.volume = MusicVol;
    }

}
