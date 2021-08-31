using System.Collections;
using System.Linq;
using UnityEngine;

public class PlayMIDI : MonoBehaviour
{
    float PlayTime = 0;
    float BPM = 300;

    KeysScript PlayingKey;

    private void Start()
    {
        ExtractDetailsFromMIDI.GetNotesFromMIDI("Assets/Resources/MIDISongs/Happy_Birthday.mid", "Assets/MIDIExtractedDetails.txt");
        ReadExtractedFile.ReadTextFile("Assets/MIDIExtractedDetails.txt");
    }
    private void Update()
    {
        playSound();
        PlayTime += (Time.deltaTime % 1000) * BPM;

    }

    void playSound()
    {
        for (int i = 0; i < ReadExtractedFile.Times.Count(); i++)
        {
            PlayingKey = GameObject.Find(ReadExtractedFile.NoteKey[i]).GetComponent<KeysScript>();
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
