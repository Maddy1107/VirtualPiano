using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using System.IO;
using System.Linq;
using UnityEngine;

public class ExtractDetailsFromMIDI : MonoBehaviour
{
    private void Start()
    {
        GetNotesFromMIDI("Assets/Resources/MIDISongs/Happy_Birthday.mid", "Assets/MIDIExtractedDetails.txt");
    }

    public static void GetNotesFromMIDI(string midiFilePath, string textFilePath)
    {
        var midiFile = MidiFile.Read(midiFilePath);

        File.WriteAllLines(textFilePath,
                        midiFile.GetNotes()
                                .Select(n => $"{n.NoteName}{n.Octave} {n.Time}"));
    }
}
