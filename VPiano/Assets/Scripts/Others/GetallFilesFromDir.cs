using System.IO;

public static class GetallFilesFromDir
{
    public static FileInfo[] AllMidis;

    public static void GetFilesfromDir()
    {
        DirectoryInfo dir = new DirectoryInfo("Assets/Resources/MIDISongs/");

        AllMidis = dir.GetFiles("*.mid");
    }
    
}
