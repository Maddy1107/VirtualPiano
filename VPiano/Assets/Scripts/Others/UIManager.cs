using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    string KeyName;

    public TextMeshProUGUI NoteText;

    public TextMeshProUGUI PlayStateText;

    public TextMeshProUGUI SongTxt;

    public GameObject SongPanel;

    public GameObject SelectSongKnob;

    GameObject knob;

    Vector3 KnobPos;
     
    RectTransform KnobrectTransform;

    Vector3 Panelpos;

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
    }

    /// <summary>
    /// Show the key name on top of the keyboard
    /// </summary>
    /// <param name="Pkey"></param>
    public void showName(GameObject Pkey)
    {
        if (Pkey.name.Contains("_Shadow"))
        {
            KeyName = Pkey.name.Replace("_Shadow", "");
        }
        if (Pkey.name.Contains("S") && Pkey.name.Contains("_Shadow"))
        {
            KeyName = Pkey.name.Replace("S", "#");
            KeyName = Pkey.name.Replace("_Shadow", "");
        }
        else
        {
            KeyName = Pkey.name;
        }

        NoteText.SetText(KeyName);
    }

    /// <summary>
    /// Set the state of the play in learn mode
    /// </summary>
    /// <param name="Statetext"></param>
    public void SetPlayText(string Statetext)
    {
        PlayStateText.SetText(Statetext);
    }

    public void CreateNewButton()
    {
        for (int i = 0; i < GetallFilesFromDir.AllMidis.Length; i++)
        {
            string txt = GetallFilesFromDir.AllMidis[i].Name;

            Panelpos = SongPanel.transform.position;

            TextMeshProUGUI sngtx = Instantiate(SongTxt, new Vector3(Panelpos.x, Panelpos.y - (i * 50), Panelpos.z), Quaternion.identity);

            var rectTransform = sngtx.GetComponent<RectTransform>();
            rectTransform.SetParent(SongPanel.transform);
            txt = txt.Replace(".mid", "");
            txt = txt.Replace("_", " ");
            sngtx.SetText(txt);
        }
        
    }

    public void CreateNewKnob()
    {
        knob = Instantiate(SelectSongKnob, new Vector3(Panelpos.x - 140, Panelpos.y, Panelpos.z), Quaternion.identity);
        KnobrectTransform = knob.GetComponent<RectTransform>();
        KnobrectTransform.SetParent(SongPanel.transform);
    }

    public void SelectSong()
    {
        if(KnobrectTransform.localPosition.y == -(GetallFilesFromDir.AllMidis.Length - 1) * 50)
        {
            KnobPos.y = 0;
        }
        else
        {
            KnobPos.y -= 50;
        }
        KnobrectTransform.localPosition = new Vector3(-140, KnobPos.y, KnobPos.z);
    }

    public Vector3 GetKnobPos()
    {
        return KnobrectTransform.localPosition;
    }
}
