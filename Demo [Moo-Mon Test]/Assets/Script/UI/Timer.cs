using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] float time = 600;
    public float _time { get { return time; } }
    private bool isCounting ;
    private void Start()
    {
        isCounting = true;
    }
    void Update()
    {
        if (isCounting)
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
            }
            else
            {
                time = 0;
                isCounting = false;
            }
            if (((int)(time % 60)) < 10)
            {
                gameObject.GetComponent<TextMeshProUGUI>().text = ((int)(time / 60)).ToString() + " : 0" + ((int)(time % 60)).ToString();
            }
            else
            {
                gameObject.GetComponent<TextMeshProUGUI>().text = ((int)(time / 60)).ToString() + " : " + ((int)(time % 60)).ToString();
            }
            
        }
    }
}
