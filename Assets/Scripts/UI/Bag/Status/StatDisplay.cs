using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatDisplay : MonoBehaviour
{
    public Text NameText;
    public Text ValueText;

    private void OnValidate()
    {
        Text[] listText = GetComponentsInChildren<Text>();
        NameText = listText[0];
        ValueText = listText[1];
    }
}
