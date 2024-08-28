using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Toggle toggle;
    [SerializeField] Slider slider;
    [SerializeField] Button button;
    void Start()
    {
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
        button.onClick.AddListener(ChangeText);
        button.onClick.AddListener(ChangeColor);
    }
    void OnToggleValueChanged (bool newvalue)
    {
        text.text=newvalue.ToString();
    }
    void ChangeColor()
    {
        text.color = Random.ColorHSV();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //ChangeText();
            slider.value = Random.Range(slider.minValue, slider.maxValue);
        }
    }

    private void ChangeText()
    {
        text.text=Random.Range(0, 1000).ToString();
    }
}
