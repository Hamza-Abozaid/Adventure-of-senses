using UnityEngine;

public class cutScript : MonoBehaviour
{
    public Transform[] Spawnpoint;
    [SerializeField] GameObject prefap;
    [SerializeField] GameObject tomato;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Array();

            Destroy(tomato.gameObject);
            Debug.Log("succses");
        }
        








        void Array()
        {

            if (Spawnpoint.Length >= 0)

                for (int i = 0; i < Spawnpoint.Length; i++)
                {
                    Instantiate(prefap, Spawnpoint[i].position, Quaternion.identity);
                }
        }
    }
}
