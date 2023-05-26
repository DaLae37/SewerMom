using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class TextLoader : MonoBehaviour
{
    public Dictionary<string, string> text = new Dictionary<string, string>(); //Text Array
    public Text Text;

    //�� �پ� ���
    private bool isChainingDone;
    private string chainingString;
    private int chainingStringIndex;

    // Use this for initialization
    void Start()
    {
        isChainingDone = true;
        LoadTextFromFile("Test");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadTextFromFile(string fileName) //Reading StoryText at TextFile's Location
    {
        TextAsset textAsset = (TextAsset)Resources.Load("Text/" + fileName); //Assets ���� ����        StringReader reader = new StringReader(textAsset.text);
        StringReader reader = new StringReader(textAsset.text);

        string readStr = null;
        while ((readStr = reader.ReadLine()) != null)
        {
            string []keyValue = readStr.Split(":");
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
    }

    //�� �پ� ���
    IEnumerator ChainingText()
    {
        isChainingDone = false;
        do
        {
            Text.text = chainingString.Substring(0, chainingStringIndex++);
            yield return new WaitForSeconds(0.1f);
        } while (chainingStringIndex != chainingString.Length);
        isChainingDone = true;
    }
}
