using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetTextScript : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUI;

    public void SetText()
    {

        switch (gameObject.name)
        {
            case "1":
                textMeshProUGUI.text = "Children's Paradise";
                break;
            case "2":
                textMeshProUGUI.text = "Dracula Castle";
                break;
            case "3":
                textMeshProUGUI.text = "Great Mountain Range";
                break;
            case "4":
                textMeshProUGUI.text = "Lost City";
                break;
            case "5":
                textMeshProUGUI.text = "Magic Forest";
                break;
            case "6":
                textMeshProUGUI.text = "Post Apocalypse";
                break;
            case "7":
                textMeshProUGUI.text = "Rocky Mountains";
                break;
            case "8":
                textMeshProUGUI.text = "The Forbidden Forest";
                break;
            case "9":
                textMeshProUGUI.text = "The Graveyard";
                break;
            case "10":
                textMeshProUGUI.text = "The Haunted Train";
                break;
            case "11":
                textMeshProUGUI.text = "The Lake";
                break;
                default: textMeshProUGUI.text = "Choose stage";
                break;

        }
    }
}
