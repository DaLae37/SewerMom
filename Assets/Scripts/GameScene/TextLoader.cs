using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class TextLoader : MonoBehaviour
{
    public static TextLoader instance;
    public Dictionary<string, string> text = new Dictionary<string, string>(); //Text Array
    public Text Text;

    public GameObject textBackground;

    //한 줄씩 출력
    private bool isChainingDone;
    private string chainingString;
    private int chainingStringIndex;

    // Use this for initialization
    void Start()
    {
        instance = this;
        isChainingDone = true;
        LoadTextFromFile("Test");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            SetText("StartRoomClose");
        }
    }

    public void LoadTextFromFile(string fileName) //Reading StoryText at TextFile's Location
    {
        TextAsset textAsset = (TextAsset)Resources.Load("Text/" + fileName); //Assets 폴더 기준        StringReader reader = new StringReader(textAsset.text);
        StringReader reader = new StringReader(textAsset.text);

        string readStr = null;
        while ((readStr = reader.ReadLine()) != null)
        {
            string[] keyValue = readStr.Split(":");
            text.Add(keyValue[0], keyValue[1]);
        }
        reader.Close();
    }

    public void SetTextSlow(string key)
    {
        if (isChainingDone)
        {
            chainingString = text[key];
            StartCoroutine("ChainingText");
        }
    }

    public void SetText(string key)
    {
        Text.text = text[key];
        textBackground.SetActive(true);
        StartCoroutine(TextCloser());
    }

    IEnumerator TextCloser()
    {
        yield return new WaitForSeconds(1f);
        Text.text = "";
        textBackground.SetActive(false);
    }
    //한 줄씩 출력
    IEnumerator ChainingText()
    {
        isChainingDone = false;
        do
        {
            Text.text = chainingString.Substring(0, chainingStringIndex++);
            yield return new WaitForSeconds(0.1f);
        } while (chainingStringIndex <= chainingString.Length);
        isChainingDone = true;
        StartCoroutine(TextCloser());
    }
}
