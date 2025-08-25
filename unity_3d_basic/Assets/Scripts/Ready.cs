using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ready : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI readyText;
    [SerializeField] int startSecond = 5;
    [SerializeField] float intervalTime = 1f;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        for(int i = 0 ; i < startSecond; i++)
        {
            readyText.SetText((startSecond - i).ToString());
            // 1초 뒤에 다음 코드를 실행하라.
            yield return new WaitForSeconds(intervalTime);
        }     
        readyText.SetText("Start");
        yield return new WaitForSeconds(intervalTime);
        readyText.gameObject.SetActive(false);
        yield return new WaitForSeconds(intervalTime);
    }

}
