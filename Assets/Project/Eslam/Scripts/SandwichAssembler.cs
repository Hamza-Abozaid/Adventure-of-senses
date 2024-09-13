using Fungus;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class SandwichAssembler : MonoBehaviour
{
  int Score = 0;
  
    [SerializeField] GameObject Botton_bread;
    [SerializeField] GameObject top_bread;
   [SerializeField] GameObject tomato;
    [SerializeField] GameObject chease;
    [SerializeField] GameObject lectt;
   [SerializeField] GameObject onion;
   [SerializeField] GameObject Sandwicburger;
    [SerializeField] Transform trans;
    [SerializeField] Flowchart flowchart;
    [SerializeField] string blockname;
    // [SerializeField] Transform botton;
    // [SerializeField] Transform toma;
    // [SerializeField] Transform chee;
    // [SerializeField] Transform lec;
    // [SerializeField] Transform onio;



    /* Instantiate(botton_bread,botton.position, Quaternion.identity);
     Instantiate(topdread, top_dread.position, Quaternion.identity);
     Instantiate(tomato, toma.position, Quaternion.identity);
     Instantiate(chease, chee.position, Quaternion.identity);
     Instantiate(lectt, lec.position, Quaternion.identity);
     Instantiate( onion, onio.position, Quaternion.identity);*/
    //          }
    //   }

    // متغير لتخزين الاسكور



    // مرجع لـ PointManager
    public PointManager pointManager;

    // كائن اللاعب
    public GameObject player;

    // منطقة التحقق (مثلاً منطقة المطبخ)
    private bool isPlayerInZone = false;

    void OnTriggerEnter(Collider other)
    {
        // تحقق مما إذا كان اللاعب دخل المنطقة
        if (other.gameObject == player)
        {
            isPlayerInZone = true;
            Debug.Log("Player entered the zone");
        }
    }

    void OnTriggerExit(Collider other)
    {
        // تحقق مما إذا كان اللاعب غادر المنطقة
        if (other.gameObject == player)
        {
            isPlayerInZone = false;
            Debug.Log("Player exited the zone");
        }
    }

    void Update()
    {
        // التحقق من الاسكور باستخدام Score من PointManager
        if (pointManager.Score ==5 && isPlayerInZone && Input.GetKeyDown(KeyCode.X))
        {
            Destroy(Botton_bread.gameObject);
            Destroy(top_bread.gameObject);
            Destroy(tomato.gameObject);
            Destroy(chease.gameObject);
            Destroy(lectt.gameObject);
            Destroy(onion.gameObject);
            Instantiate(Sandwicburger, trans.position, Quaternion.identity);
            flowchart.ExecuteBlock(blockname);
            pointManager.UpdateScore(-5);
            Destroy(gameObject);
            

            // يمكنك إضافة أكشن معين عند تحقق الشرط
        }
    }

} 
    
   



