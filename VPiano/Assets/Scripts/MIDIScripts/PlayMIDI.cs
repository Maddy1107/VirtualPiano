using System.Collections;
using System.Linq;
using UnityEngine;

public class PlayMIDI : MonoBehaviour
{
    float PlayTime = 0;
    float BPM = 300;

    public KeysScript PlayingKey;

    public GameObject ShadowP;

    public bool StartPlay = false;

    private void Update()
    {
        if(StartPlay)
        {
            playSound();
            IncreasePlayTime();
            UIManager.instance.SetPlayText("Playing: ");
        }
        else if(PlayTime != 0)
        {
            UIManager.instance.SetPlayText("Paused: ");
        }
        else
        {
            UIManager.instance.SetPlayText("Ready to play: ");
        }

        if (PlayTime >= ReadExtractedFile.Times[ReadExtractedFile.Times.Count() - 1] + 5)
        {
            StartPlay = false;
            PlayTime = 0;
        }
    }

    void IncreasePlayTime()
    {
        PlayTime += (Time.deltaTime % 1000) * BPM;
    }

    void playSound()
    {
        for (int i = 0; i < ReadExtractedFile.Times.Count(); i++)
        {
            PlayingKey = GameObject.Find(ReadExtractedFile.NoteKey[i] + "_Shadow").GetComponent<KeysScript>();
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
