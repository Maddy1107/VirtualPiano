using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    string KeyName;

    public TextMeshProUGUI NoteText;

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
        if (Pkey.name.Contains("S"))
        {
            KeyName = Pkey.name.Replace("S", "#");

        }
        else
        {
            KeyName = Pkey.name;
        }

        NoteText.SetText(KeyName);
    }
}
