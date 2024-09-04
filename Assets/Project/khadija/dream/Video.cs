using UnityEngine;
using UnityEngine.Video;
using Fungus;

public class Video : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject playerSleeping;
    public GameObject playerAwake;
    public Flowchart flowchart; // ��� ����� �Flowchart
    public string sayBlockName; // ��� Say Block �� Fungus

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

        // ����� Say Block
        flowchart.ExecuteBlock(sayBlockName);
    }

    // ���� ������� ��� ������ ��� ������ Say Block �� Fungus
    public void OnSayFinished()
    {
        // ����� ������ ������ ���� ������ ��������
        playerSleeping.SetActive(false);
        playerAwake.SetActive(true);
    }
}