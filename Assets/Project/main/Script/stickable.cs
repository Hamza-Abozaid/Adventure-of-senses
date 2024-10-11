using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followmouse : MonoBehaviour
{

    public PointManager pointManager;
    public LayerMask stickableLayer; // تعريف الـ Layer التي يمكن الالتصاق بها
    [SerializeField] GameObject prefap;
    [SerializeField] GameObject prefap1;
    [SerializeField] GameObject prefap2;
    [SerializeField] GameObject prefap3;
    [SerializeField] GameObject prefap4;
    [SerializeField] GameObject prefap5;
    [SerializeField] GameObject prefap6;    
    [SerializeField] GameObject prefap7;
    [SerializeField] Flowchart flowchart;
    [SerializeField] string blockname;
    public Transform Spawnpoint;
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        // تحقق إذا كان الكائن الذي تصطدم به موجودًا في الـ Layer المحددة
        if ((stickableLayer.value & 1 << collision.gameObject.layer) != 0)
        {
            // اجعل الكائن الملتصق تابعًا للكائن الذي تم التصادم معه
            collision.transform.SetParent(transform);

            // تعطيل الفيزياء لجعل الكائن يلتصق
            if (collision.rigidbody != null)
            {
                collision.rigidbody.isKinematic = true;
            }

            // تعطيل الـ BoxCollider إذا كان موجودًا
           BoxCollider boxCollider = collision.gameObject.GetComponent<BoxCollider>();
          if (boxCollider != null)
          {
              boxCollider.enabled = false;
            }

            // تعيين قيم X و Z من الكائن الذي تم التصادم معه، مع الحفاظ على Y
            Vector3 newPosition = transform.position;
            newPosition.y = collision.transform.position.y; // الحفاظ على ارتفاع الكائن
            collision.transform.position = newPosition;
            pointManager.UpdateScore(1);
            Debug.Log(pointManager.Score);
        }
        if (pointManager.Score == 6)
        {
            flowchart.ExecuteBlock(blockname);
            Destroy(prefap1);
            Destroy(prefap2);
            Destroy(prefap3);
            Destroy(prefap4);
            Destroy(prefap5);
            Destroy(prefap6);
            Destroy(prefap7);
            Instantiate(prefap, Spawnpoint.position, Quaternion.identity);
        }
    }

}

    
