using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    public Material inactiveMaterial;
    public Material activeMaterial;

    private MeshRenderer mr;
    private bool active;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        mr = GetComponent<MeshRenderer>();

        if(mr != null)
        {
            mr.material = inactiveMaterial;
        }

        active = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        // tiles should turn active only when player is on for the whole duration
        if (mr != null)
        {
            mr.material = activeMaterial;
        }

        if(audioSource != null)
        {
            audioSource.PlayOneShot(audioSource.clip);
        }

        active = true;
    }

    private void OnTriggerExit(Collider other)
    {
        // disable tiles is player steps off to early
        if (mr != null)
        {
            mr.material = inactiveMaterial;
        }

        active = false;
    }

    public bool isActive()
    {
        return active;
    }

    public void ResetActice()
    {
        active = false;
        if(mr != null)
        {
            mr.material = inactiveMaterial;
        }
    }
}
