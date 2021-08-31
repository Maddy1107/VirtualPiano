using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using System.IO;
using System.Linq;

public static class ExtractDetailsFromMIDI
{
    public static void GetNotesFromMIDI(string midiFilePath, string textFilePath)
    {
        var midiFile = MidiFile.Read(midiFilePath);

        File.WriteAllLines(textFilePath,
                        midiFile.GetNotes()
                                .Select(n => $"{n.NoteName}{n.Octave} {n.Time}"));
    }
}
