using UnityEngine;

public class BgmController : MonoBehaviour
{
    public AudioSource bgmSource;


    private void OnEnable()
    {
        PlayerRaycast.OnStopBackgroundMusic += StopBgm;
    }

    private void OnDisable()
    {
        PlayerRaycast.OnStopBackgroundMusic -= StopBgm;
    }

    private void StopBgm()
    {
        if (bgmSource != null && bgmSource.isPlaying)
        {
            bgmSource.Stop();
        }
    }
}
