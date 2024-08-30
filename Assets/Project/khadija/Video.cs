using UnityEngine;
using UnityEngine.Video;

public class Video : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject playerSleeping;
    public GameObject playerAwake;

    void Start()
    {
        // ÅÎİÇÁ ÇááÇÚÈ ÇáãÓÊíŞÙ æÚÑÖ ÇááÇÚÈ ÇáäÇÆã
        playerAwake.SetActive(false);
        playerSleeping.SetActive(true);

        // ÈÏÁ ÇáİíÏíæ
        videoPlayer.Play();

        // ÊÍÏíÏ ãÇ íÍÏË ÈÚÏ ÇäÊåÇÁ ÇáİíÏíæ
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        // ÅÎİÇÁ ÇáİíÏíæ
        vp.gameObject.SetActive(false);

        // ÅÎİÇÁ ÇááÇÚÈ ÇáäÇÆã æÚÑÖ ÇááÇÚÈ ÇáãÓÊíŞÙ
        playerSleeping.SetActive(false);
        playerAwake.SetActive(true);
    }
}