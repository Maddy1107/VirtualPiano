using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using System.IO;
using System.Linq;

public static class ExtractDetailsFromMIDI
{
    /// <summary>
    /// Parse the MIDI file and get the respective notes
    /// Also write the notes and teh playtime in the given file.
    /// </summary>
    /// <param name="midiFilePath"></param>
    /// <param name="textFilePath"></param>
    public static void GetNotesFromMIDI(string midiFilePath, string textFilePath)
    {
        var midiFile = MidiFile.Read(midiFilePath);

        File.WriteAllLines(textFilePath,
                        midiFile.GetNotes()
                                .Select(n => $"{n.NoteName}{n.Octave} {n.Time}"));
    }
}
