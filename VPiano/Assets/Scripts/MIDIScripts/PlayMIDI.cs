using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class PlayMIDI : MonoBehaviour
{
    float PlayTime;
    //float BPM = 300;

    public KeysScript PlayingKey;

    public bool StartPlay;

    private void OnEnable()
    {
        ResetPlay();
    }

    private void Update()
    {
        if(StartPlay)
        {
            playSound();
            IncreasePlayTime();
            UIManager.instance.SetPlayText("Playing: ");
        }
        else if(!StartPlay && PlayTime != 0)
        {
            UIManager.instance.SetPlayText("Paused: ");
        }
        else
        {
            UIManager.instance.SetPlayText("Ready to play: ");
        }

        if (ReadExtractedFile.Times.Count != 0)
        {
            if (PlayTime >= ReadExtractedFile.Times[ReadExtractedFile.Times.Count() - 1] + 5)
            {
                ResetPlay();
            }
        }
    }

    void IncreasePlayTime()
    {
        PlayTime += (Time.deltaTime % 1000) * BPMScript.GetBPM();
    }

    void playSound()
    {
        for (int i = 0; i < ReadExtractedFile.Times.Count(); i++)
        {
            GameObject[] keys = GameObject.FindGameObjectsWithTag("ShadowKeys");
            foreach (GameObject k in keys)
            {
                if (k.name == ReadExtractedFile.NoteKey[i] + "_Shadow")
                {
                    PlayingKey = k.GetComponent<KeysScript>();
                }

            }

            if ((int)PlayTime <= ReadExtractedFile.Times[i] + 2 && (int)PlayTime >= ReadExtractedFile.Times[i] - 2)
            {
                if (PlayingKey.gameObject.tag == "ShadowKeys")
                {
                    PlayingKey.KeyPressed();
                    StartCoroutine(WaitAndRestore(500));
                }
            }
        }
    }

    public void StartstopPlayBool()
    {
        StartPlay = !StartPlay;
    }

    public void ExtractandRead(string songName)
    {
        ExtractDetailsFromMIDI.GetNotesFromMIDI("Assets/Resources/MIDISongs/" + songName, "Assets/MIDIExtractedDetails.txt");
        ReadExtractedFile.ReadTextFile("Assets/MIDIExtractedDetails.txt");
        ResetPlay();
    }

    public void ConfirmSong()
    {
        String sngnme = GetallFilesFromDir.AllMidis[(int)UIManager.instance.GetKnobPos().y / 50].Name;
        ExtractandRead(sngnme);
        UIManager.instance.SetPlayText(sngnme);
        Debug.Log(sngnme);
    }

    public void ResetPlay()
    {
        StartPlay = false;
        PlayTime = 0;
    }

    IEnumerator WaitAndRestore(float timeInMilliseconds)
    {
        var stopwatch = new System.Diagnostics.Stopwatch();
        stopwatch.Start();
        while (stopwatch.ElapsedMilliseconds < timeInMilliseconds)
        {
            yield return null;
        }
        stopwatch.Stop();
        PlayingKey.KeyUnPressed();
    }
}
