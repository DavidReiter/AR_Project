using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasController : MonoBehaviour
{
    [SerializeField]
    public TMP_Text counter;
    public TMP_Text timer;

    // Start is called before the first frame update
    void Start()
    {
        if (counter != null && timer != null)
        {
            counter.SetText("Targets: 0");
            timer.SetText("0:00");
        } 
    }

    public void SetCounter(int count)
    {
        if(counter != null)
        {
            counter.SetText("Targets: " +  count);
        }
    }

    public void SetTimer(float time)
    {
        if(timer != null)
        {
            string elapsed = time.ToString("F2");
            timer.SetText(elapsed);
        }
    }
}
