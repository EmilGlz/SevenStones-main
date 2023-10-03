using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestTween : MonoBehaviour
{
    [SerializeField] RectTransform threeIcon;
    [SerializeField] RectTransform ball;
    [SerializeField] RectTransform stone;
    [SerializeField] RectTransform star;
    [SerializeField] RectTransform cup;
    [SerializeField] RectTransform mvp;
    [SerializeField] RectTransform coin;
    [SerializeField] RectTransform XP;
    [SerializeField] TMP_Text cnTxt;
    [SerializeField] TMP_Text xpTxt;
    private GameObject[] randomPoss;

    private void Start()
    {
        randomPoss = new GameObject[7];
        for (int i = 0; i < 7; i++)
        {
            randomPoss[i] = new GameObject();
        }
        //StartCoroutine(Last5Secs());
        //threeIcon.localScale = Vector3.zero;
        //ball.localScale = Vector3.zero;
        //stone.localScale = Vector3.zero;
        //star.localScale = Vector3.zero;
        //cup.localScale = Vector3.zero;
        //mvp.localScale = Vector3.zero;
        //StartCoroutine(Wait());
    }

    IEnumerator Last5Secs()
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < 4; i++)
        {
            AudioManager.Instance.Play(19);
            yield return new WaitForSeconds(1f);
        }
        AudioManager.Instance.Play(20);
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        TweenThreeImage();
        yield return new WaitForSeconds(.5f);
        TweenBllStnStr();
        yield return new WaitForSeconds(.9f);
        TweenCpMVP();
        yield return new WaitForSeconds(1f);
        TweenCnXP(1200, 300);
    }

    private void TweenThreeImage()
    {
        LeanTween.scale(threeIcon, Vector3.one, .5f).setEaseOutBack();
    }
    private void TweenBllStnStr()
    {
        LeanTween.scale(ball.GetComponent<RectTransform>(), Vector3.one, .3f).setEaseOutBack()
            .setOnComplete(() => { LeanTween.scale(stone, Vector3.one, .3f).setEaseOutBack().setOnComplete(() => { LeanTween.scale(star, Vector3.one, .3f).setEaseOutBack(); }); });
        //.setOnComplete(() => { LeanTween.scale(star, Vector3.one, .3f).setEaseOutBack(); });
    }
    private void TweenCpMVP()
    {
        LeanTween.scale(cup, Vector3.one, .5f).setEaseOutBack().setOnComplete(() => { LeanTween.scale(mvp, Vector3.one, .5f).setEaseOutBack(); });
    }
    private void TweenCnXP(int coin, int xp)
    {
        LeanTween.value(gameObject, 0, coin, .5f)
            .setEaseOutSine()
            .setOnUpdate(ChangeTextCoin)
            .setOnComplete(() => {
                LeanTween.value(gameObject, 0, xp, .5f)
                    .setEaseOutSine()
                    .setOnUpdate(ChangeTextXP);
            });
    }

    private void ChangeTextCoin(float value)
    {
        cnTxt.text = string.Format("+{0}", (int)value);
    }
    private void ChangeTextXP(float value)
    {
        xpTxt.text = string.Format("+{0}", (int)value);
    }
}
