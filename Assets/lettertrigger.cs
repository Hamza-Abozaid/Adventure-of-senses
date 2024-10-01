using TMPro;
using UnityEngine;

public class lettertrigger : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI uiText;
    private int triggerCount = 0;  // عداد لتتبع عدد مرات تفعيل الـ Trigger
    private int maxTriggers = 2;   // أقصى عدد مرات لتفعيل الـ Trigger

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && triggerCount < maxTriggers)  // تأكد إن البلاير ليه الـ Tag "Player" وعدد المرات لم يتجاوز الحد
        {
            uiText.enabled = true;  // يخلي النص يظهر
            triggerCount++;         // زوّد العداد
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && triggerCount <= maxTriggers) // تأكد إن العداد لم يتجاوز الحد
        {
            uiText.enabled = false;  // يخلي النص يختفي
        }
    }
}