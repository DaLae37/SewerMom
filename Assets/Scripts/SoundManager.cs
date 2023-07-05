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
�κ�bgm 0
������ 1
�ѱ�� ���� 2

Effect
�κ� UI ���� : �κ�UIŬ�� 0
���ݸ� �Դ� �Ҹ� 1
��� �������� �Ҹ�2
ö�� ���� �Ҹ� 3
ö�� �ݴ� �Ҹ� 4
������ ���� �Ҹ� : ������ ���� �Ҹ� 5
������ �ݴ� �Ҹ� : ������ �ݴ� �Ҹ� 6
������ ������ ������ �Ҹ� : ������ ������ ������ �Ҹ� 7
�� ó���κ� �� �������� �� 8
��� �� : 9
������ Ű�� �Ҹ� : 10
����ö ���� �浹 ���� ��� 11
�������� ������ �� 12
�Ź��� ��ȣ�ۿ� 13
��ٸ� ������ �Ҹ� 14
��ٸ� �������� �Ҹ� 15
��й�ȣ ������ 16
��й�ȣ Ʋ���� �� 17
����� �� ���°� 18
�� Ÿ�� �� 19
ĳ��� 20
���� �ݴ°�  21
ġ��� ������ �ݴ� �� 22
������ �ݴ°� 23

Special
���� �߼Ҹ�
���� �߼Ҹ�
�㰡 �������� �˸��� �Ҹ�
����ö �Ҹ� : ����ö(������)
*/