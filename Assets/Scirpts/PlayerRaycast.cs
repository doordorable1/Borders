using UnityEngine;
using System;

public class PlayerRaycast : MonoBehaviour
{
    public bool drawDebugRay = true;

    [Header("Audio")]
    public AudioClip anySFX;
    public AudioSource audioSource;

    public static event Action OnStopBackgroundMusic;

    private Camera cam;
    private LayerMask layerMask = ~(1 << 2);
    private float rayMaxDistance = 100f;

    private void Start()
    {
    }

    public void TryInteract()
    {
        if (cam == null) cam = GetComponent<Camera>();
        Vector2 screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = cam.ScreenPointToRay(screenCenter);

        if (Physics.Raycast(ray, out RaycastHit hit, rayMaxDistance, layerMask))
        {
            if (hit.collider.CompareTag("Finish"))
            {
                hit.collider.gameObject.SetActive(false);
                Debug.Log("time is " + hit.collider.name);
                PlayFinishSound();
                
            }
        }
    }

    private void PlayFinishSound()
    {
        OnStopBackgroundMusic.Invoke();
        if (anySFX != null && audioSource != null)
        {
            audioSource.clip = anySFX;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("PlayFinishSound: AudioSource or AudioClip not assigned.");
        }
    }

    
}
