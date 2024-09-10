using Fungus;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class cutScript : MonoBehaviour
{
    public Transform Spawnpoint;
    [SerializeField] GameObject prefap;
    [SerializeField] GameObject tomato;
    public PointManager pointManager;
    [SerializeField] Flowchart flowchart;
    [SerializeField] string blockname;
  

     void Update()
    {
     Debug.Log(pointManager.Score);
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.name == "knife")
        { 
            pointManager.UpdateScore(1);
            Destroy(gameObject);
            Instantiate(prefap, Spawnpoint.position, Quaternion.identity);
        }
        if (pointManager.Score == 4)
            {
            flowchart.ExecuteBlock(blockname);
            }
    }








}



