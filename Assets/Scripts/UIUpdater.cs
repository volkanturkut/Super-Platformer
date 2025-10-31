using UnityEngine;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour
{
    public Text uiText;


    public void UpdateUIText()
    {
        if (Application.isPlaying)
        {
            uiText.text = "Player has respawned!";
        }
    }
}