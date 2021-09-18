using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerGauge : MonoBehaviour
{
    [SerializeField] Slider powerBar;
    [SerializeField] TextMeshProUGUI powerValue;
    [SerializeField] float gaugeSpeed;
    void Start()
    {
        powerBar.value = 0;
    }
    void Update()
    {
        powerValue.text = ((int)powerBar.value).ToString();
        powerBar.value += Time.deltaTime * gaugeSpeed;

    }
}
