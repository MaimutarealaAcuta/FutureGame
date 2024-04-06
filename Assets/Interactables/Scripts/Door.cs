using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, Triggerable
{
    enum DoorState
    {
        Open,
        Closed
    };

    [SerializeField] private DoorState doorState = DoorState.Closed;
    private Vector3 offset = new Vector3(0, 15, 0);
    private bool opening = false;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Trigger()
    {
        if (opening) return;

        opening = true;
        StartCoroutine(OpenDoor());
        audioSource.Play();
    }

    IEnumerator OpenDoor()
    {
        float t = 0;
        Vector3 start = transform.position;
        Vector3 end = transform.position + offset * (doorState == DoorState.Closed ? 1 : -1);
        doorState = (doorState == DoorState.Closed) ? DoorState.Open : DoorState.Closed;
        while (t < 1)
        {
            t += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, t);
            yield return null;
        }
        opening = false;
    }


}
