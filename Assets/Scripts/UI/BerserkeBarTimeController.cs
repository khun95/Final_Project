using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BerserkeBarTimeController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Slider BossBerserkeBar;
    [SerializeField] float berserkTime;
    float maxBerserkTime;
    public static bool isBerserk;
    [SerializeField] TextMeshProUGUI timeText;
    void Start()
    {
        maxBerserkTime = berserkTime;
    }
    private void OnEnable()
    {
        StartCoroutine(BerserkeTimeDescrease());
    }
    IEnumerator BerserkeTimeDescrease()
    {
        while (berserkTime >= 0)
        {
            yield return new WaitForSeconds(1f);
            berserkTime--;
        }
    }
    // Update is called once per frame
    void Update()
    {
        BossBerserkeBar.value = berserkTime / maxBerserkTime;
        if(berserkTime == 0)
        {
            isBerserk = true;
            timeText.gameObject.SetActive(true);
        }
    }

}
