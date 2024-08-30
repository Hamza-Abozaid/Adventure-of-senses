using UnityEngine;
using UnityEngine.Video;

public class Video : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject playerSleeping;
    public GameObject playerAwake;

    void Start()
    {
        // ����� ������ �������� ���� ������ ������
        playerAwake.SetActive(false);
        playerSleeping.SetActive(true);

        // ��� �������
        videoPlayer.Play();

        // ����� �� ���� ��� ������ �������
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        // ����� �������
        vp.gameObject.SetActive(false);

        // ����� ������ ������ ���� ������ ��������
        playerSleeping.SetActive(false);
        playerAwake.SetActive(true);
    }
}