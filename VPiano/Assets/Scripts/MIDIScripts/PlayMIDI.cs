using System.Linq;
using UnityEngine;
using System;

public class PlayMIDI : MonoBehaviour
{
    public bool isPlaying;

    private float PlayTime;

    public KeysScript PlayingKey;
    private GameObject CurrKey;
    private GameObject[] keys;

    public static Action<GameObject> PressButton;

    private void OnEnable()
    {
        ResetPlay();
        keys = GameObject.FindGameObjectsWithTag("ShadowKeys");
    }

    private void Update()
    {
        if (ReadExtractedFile.Times.Count != 0)
        {
            if (PlayTime >= ReadExtractedFile.Times[ReadExtractedFile.Times.Count() - 1] + 5)
            {
                ResetPlay();
            }
        }

        SongLogic();
    }

    private void SongLogic()
    {
        if (isPlaying)
        {
            playSound();
            IncreasePlayTime();
            UIManager.instance.SetPlayText("Playing: ");
        }

        else if (!isPlaying && PlayTime != 0)
        {
            UIManager.instance.SetPlayText("Paused: ");
        }

        else
        {
            UIManager.instance.SetPlayText("Ready to play: ");
        }
    }

    private void IncreasePlayTime()
    {
        PlayTime += (Time.deltaTime % 1000) * BPMScript.GetBPM();
    }

    private void playSound()
    {
        for (int i = 0; i < ReadExtractedFile.Times.Count(); i++)
        {
            InitialiseKeys(i);

            if ((int)PlayTime <= ReadExtractedFile.Times[i] + 5 && (int)PlayTime >= ReadExtractedFile.Times[i] - 5)
            {
                if (PlayingKey.gameObject.tag == "ShadowKeys")
                {
                    PlayingKey.KeyPressed();
                    PressButton?.Invoke(CurrKey);
                }
            }
        }
    }

    private void InitialiseKeys(int currKey)
    {
        foreach (GameObject k in keys)
        {
            if (k.name == ReadExtractedFile.NoteKey[currKey] + "_Shadow")
            {
                PlayingKey = k.GetComponent<KeysScript>();
                CurrKey = k;
            }
        }
    }

    public void StartstopPlayBool()
    {
        isPlaying = !isPlaying;
    }

    public void ExtractandRead(string songName)
    {
        ExtractDetailsFromMIDI.GetNotesFromMIDI("Assets/Resources/MIDISongs/" + songName, "Assets/MIDIExtractedDetails.txt");
        ReadExtractedFile.ReadTextFile("Assets/MIDIExtractedDetails.txt");

        ResetPlay();
    }

    public void ResetPlay()
    {
        isPlaying = false;
        PlayTime = 0;
    }

    /*IEnumerator WaitAndRestore(float timeInMilliseconds)
    {
        var stopwatch = new System.Diagnostics.Stopwatch();
        stopwatch.Start();
        while (stopwatch.ElapsedMilliseconds < timeInMilliseconds)
        {
            yield return null;
        }
        stopwatch.Stop();
        PlayingKey.KeyUnPressed();
    }*/
}
