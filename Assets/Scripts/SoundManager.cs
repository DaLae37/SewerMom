using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource bgm;
    public AudioSource effect;
    public AudioClip []bgmList;
    public AudioClip []effectList;

    public AudioSource player;
    public AudioSource mom;
    public AudioSource mouse;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
            bgm = transform.Find("BGM").GetComponent<AudioSource>();
            effect = transform.Find("Effect").GetComponent<AudioSource>();
            player = transform.Find("Player").GetComponent<AudioSource>();
            mom = transform.Find("Mom").GetComponent<AudioSource>();
            mouse = transform.Find("Mouse").GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayerOn()
    {
        if (!player.isPlaying)
        {
            player.Play();
        }
    }

    public void PlayerOff()
    {
        player.Stop();
    }

    public void MomOn()
    {
        if (!mom.isPlaying) { 
        
        mom.Play();}
    }

    public void MomOff()
    {
        mom.Stop();
    }

    public void MouseOn()
    {
        if (!mouse.isPlaying)
        {
            mouse.Play();
        }
    }

    public void MouseOff()
    {
        mouse.Stop();
    }

    public void PlayBGM(int index)
    {
        StopBGM();
        bgm.clip = bgmList[index];
        bgm.Play();
    }

    public void StopBGM()
    {
        bgm.Stop();
    }

    public void PlayEffect(int index)
    {
        effect.PlayOneShot(effectList[index]);
    }

    public void StopEffect()
    {
        effect.Stop();
    }
}

/*
BGM
로비bgm 0
놀이터 1
쫓기는 상태 2

Effect
로비 UI 선택 : 로비UI클릭 0
초콜릿 먹는 소리 1
계단 내려가는 소리2
철문 여는 소리 3
철문 닫는 소리 4
나무문 여는 소리 : 나무문 여는 소리 5
나무문 닫는 소리 : 나무문 닫는 소리 6
나무문 강제로 닫히는 소리 : 나무문 강제로 닫히는 소리 7
맨 처음부분 쥐 따라오라는 거 8
잠긴 문 : 9
손전등 키는 소리 : 10
지하철 괴물 충돌 괴물 비명 11
괴물한테 잡혔을 때 12
신문지 상호작용 13
사다리 오르는 소리 14
사다리 내려오는 소리 15
비밀번호 누르는 16
비밀번호 틀렸을 때 17
열쇠로 문 여는거 18
문 타는 거 19
캐비닛 20
열쇠 줍는거  21
치즈랑 라이터 줍는 거 22
손전등 줍는거 23

Special
아이 발소리
괴물 발소리
쥐가 괴물한테 알리는 소리
지하철 소리 : 지하철(고막주의)
*/