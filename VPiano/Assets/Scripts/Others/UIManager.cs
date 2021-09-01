using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    string KeyName;

    public TextMeshProUGUI NoteText;

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
    }

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

    public void SetPlayText(string Statetext)
    {
        PlayStateText.SetText(Statetext);
    }
}
