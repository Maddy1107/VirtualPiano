using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    private AudioSource MainMenuAudio;

    public static UIManager instance;

    string KeyName;

    public TextMeshProUGUI NoteTextLearn;

    public TextMeshProUGUI NoteTextInGame;

    public TextMeshProUGUI PlayStateText;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        MainMenuAudio = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Show the key name on top of the keyboard
    /// </summary>
    /// <param name="Pkey"></param>
    public void showName(GameObject Pkey)
    {
        if(Pkey.name.Contains("_Shadow"))
        {
            CorrectKeyNamesLearn(Pkey);
            NoteTextLearn.SetText(KeyName);
        }
        else
        {
            CorrectKeyNamesInGame(Pkey);
            NoteTextInGame.SetText(KeyName);
        }
        
    }

    void CorrectKeyNamesInGame(GameObject Pkey)
    {
        if (Pkey.name.Contains("S"))
        {
            KeyName = Pkey.name.Replace("S", "#");
        }
        else
        {
            KeyName = Pkey.name;
        }
    }

    void CorrectKeyNamesLearn(GameObject Pkey)
    {
        if (System.Text.RegularExpressions.Regex.IsMatch(Pkey.name, "[A-Z]S[0-9]"))
        {
            KeyName = Pkey.name.Replace("_Shadow", "");
            KeyName = KeyName.Replace("S", "#");
        }
        else
        {
            KeyName = Pkey.name.Replace("_Shadow", "");
        }
    }
    /// <summary>
    /// Set the state of the play in learn mode
    /// </summary>
    /// <param name="Statetext"></param>
    public void SetPlayText(string Statetext)
    {
        PlayStateText.SetText(Statetext);
    }

    public void AudioPlay()
    {
        MainMenuAudio.Play();
    }

    public void AudioStop()
    {
        MainMenuAudio.Stop();
    }
}
