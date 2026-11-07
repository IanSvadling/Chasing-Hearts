using UnityEngine;
using TMPro;

public class CounterUI : MonoBehaviour
{
    [SerializeField] private TMP_Text counterText;

    private void Update()
    {
        if(HeartCollecting.Instance == null)
        {
            return;
        }

        counterText.text = HeartCollecting.Instance.HeartCounter.ToString();
    }
}
