using Fungus;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class cutScript : MonoBehaviour
{
    public Transform[] Spawnpoint;
    [SerializeField] GameObject prefap;
    [SerializeField] GameObject tomato;
    public PointManager pointManager;
    [SerializeField] Flowchart flowchart;
    [SerializeField] string blockname;
  

     void Update()
    {
        ///if (pointManager.Score==0 &&plus==1 )
///{
     //     ///////  pointManager.UpdateScore(1);
///Debug.Log(pointManager.Score);
       ///////// }
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.name == "knife")
        {
            Destroy(gameObject);
            Array();


        }
    }








    void Array()
    {

        if (Spawnpoint.Length >= 0)

            for (int i = 0; i < Spawnpoint.Length; i++)
            {
                Instantiate(prefap, Spawnpoint[i].position, Quaternion.identity);
                flowchart.ExecuteBlock(blockname);
            }
    }
}



