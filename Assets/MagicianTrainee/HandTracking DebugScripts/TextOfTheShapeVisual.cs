using System;
using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using TMPro;
using UnityEngine;

public class TextOfTheShapeVisual : MonoBehaviour
{
    [SerializeField] private List<ActiveStateSelector> _poses;
    [SerializeField] private TextMeshProUGUI _text;

    private void Start()
    {
        foreach (var item in _poses)
        {
            item.WhenSelected += () => SetTextToPoseName(item.gameObject.name);
            item.WhenUnselected += () => SetTextToPoseName("");
        }
    }

    private void SetTextToPoseName(string text)
    {
        _text.text = text;
    }
}
