using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneController : MonoBehaviour {

    public bool isMicUse = true;
    private string selectedMic;

    AudioSource audioSource;

    private float micLoundness;
    private int _sampleWindow = 128;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        InitMic();
    }

    // Update is called once per frame
    void Update() {
        micLoundness = GetLoundnessInDecibel();

        //Debug.Log(micLoundness);
    }

    // Start using microphone.
    void InitMic() {
        if (selectedMic == null) {
            selectedMic = Microphone.devices[0];
        }

        audioSource.clip = Microphone.Start(selectedMic, true, 999, AudioSettings.outputSampleRate);
    }

    // Stop using microphone.
    void StopMic() {
        Microphone.End(selectedMic);
    }

    float GetLoundnessInDecibel() {
        float db = 10 * Mathf.Log10(GetLoundness() / Mathf.Pow(10, -12));
        
        return db;
    }

    float GetLoundness() {
        float levelMax = 0;
        float[] waveData = new float[_sampleWindow];
        int micPosition = Microphone.GetPosition(null) - (_sampleWindow + 1); // null means the first microphone

        if (micPosition < 0) return 0;

        audioSource.clip.GetData(waveData, micPosition);

        // Getting a peak on the last 128 samples
        for (int i = 0; i < _sampleWindow; i++)
        {
            float wavePeak = waveData[i] * waveData[i];
            if (levelMax < wavePeak)
            {
                levelMax = wavePeak;
            }
        }
        return levelMax;
    }

}
