using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using Vuforia;

public class VButtonController : MonoBehaviour
{

    public UnityEvent OnPressed;
    public UnityEvent OnReleased;

// Disable virtual button deprecated warning
#pragma warning disable CS0618 

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnButtonPressed);
        GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(OnButtonReleased);
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        OnPressed.Invoke();
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        OnReleased.Invoke();
    }

#pragma warning restore CS0618
}
