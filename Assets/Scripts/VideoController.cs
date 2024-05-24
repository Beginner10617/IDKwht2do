using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Canvas MainMenu;

    void Start()
    {
        // Disable the canvas at the start
        MainMenu.enabled = false;

        // Add a listener to the video player's loopPointReached event
        videoPlayer.loopPointReached += OnVideoEnded;
    }

    void OnVideoEnded(VideoPlayer vp)
    {
        // Enable the canvas when the video ends
        Debug.Log("Video ended");
        MainMenu.enabled = true;
        Debug.Log("Canvas enabled: " + MainMenu.enabled);
    }
}