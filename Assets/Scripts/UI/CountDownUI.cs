using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDownUI : MonoBehaviour
{
    private const string IS_SHAKE = "isShake";

    [SerializeField] private TextMeshProUGUI numberText;

    private Animator anim;

    private int preNumber = -1;
    private void Start()
    {
        anim = GetComponent<Animator>();
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;
    }

    private void Update()
    {
        if (GameManager.Instance.IsCountDownState())
        {
            int nowNumber = Mathf.CeilToInt(GameManager.Instance.GetCountDownTimer());
            numberText.text = nowNumber.ToString();
            if (nowNumber != preNumber)
            {
                preNumber = nowNumber;
                anim.SetTrigger(IS_SHAKE);
                SoundManager.Instance.PlayCountDownSound();
            }
            
        }
    }
    private void GameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.IsCountDownState())
        {
            numberText.gameObject.SetActive(true);
        }
        else
        {
            numberText.gameObject.SetActive(false);
        }
    }
}
