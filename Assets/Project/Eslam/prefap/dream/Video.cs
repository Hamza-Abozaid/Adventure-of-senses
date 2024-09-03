using UnityEngine;
using UnityEngine.Video;
using Fungus;

public class Video : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject playerSleeping;
    public GameObject playerAwake;
    public Flowchart flowchart; // ÇÖİ ãÊÛíÑ áFlowchart
    public string sayBlockName; // ÇÓã Say Block İí Fungus

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

        // ÊÔÛíá Say Block
        flowchart.ExecuteBlock(sayBlockName);
    }

    // ÓíÊã ÇÓÊÏÚÇÁ åĞå ÇáÏÇáÉ ÚäÏ ÇäÊåÇÁ Say Block İí Fungus
    public void OnSayFinished()
    {
        // ÅÎİÇÁ ÇááÇÚÈ ÇáäÇÆã æÚÑÖ ÇááÇÚÈ ÇáãÓÊíŞÙ
        playerSleeping.SetActive(false);
        playerAwake.SetActive(true);
    }
}