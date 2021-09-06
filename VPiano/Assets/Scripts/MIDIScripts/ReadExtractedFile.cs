using System.Collections.Generic;
using System.IO;

public static class ReadExtractedFile
{
    public static List<string> NoteKey = new List<string>();
    public static List<float> Times = new List<float>();

    /// <summary>
    /// Parse the file with the notes and playtime
    /// File is read line by line and split from blank space
    /// Store the notes in the Notekey List and playtime in the Times List
    /// </summary>
    /// <param name="file_path"></param>
    public static void ReadTextFile(string file_path)
    {
        NoteKey.Clear();
        Times.Clear();
        var sr = new StreamReader(file_path);
        var fileContents = sr.ReadToEnd();
        sr.Close();

        var lines = fileContents.Split("\n"[0]);
        for (int line = 0; line < lines.Length - 1; line++)
        {
            var l = lines[line].Split(' ');
            if (l[0].Contains("Sharp"))
            {
                NoteKey.Add(l[0].Replace("Sharp", "S"));
            }
            else
            {
                NoteKey.Add(l[0]);
            }

            Times.Add((int)float.Parse(l[1]));
        }
    }
}
