using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCCollisionController : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public GameObject quizBoard;
    string answer;
    string lastText;

    void Start()
    {
        textMesh.text = "이화여자대학교에 온 것을 환영합니다!\n당신은 현재 정문에 있습니다!\n눈 앞에 바로 건물이 보이네요. 건물 앞의 NPC에게 다가가 봅시다.";
    }

    void SetQuizText(string first, string second, string third, string fourth)
    {
        quizBoard.transform.Find("First").transform.Find("Text").GetComponent<TextMeshProUGUI>().text = first;
        quizBoard.transform.Find("Second").transform.Find("Text").GetComponent<TextMeshProUGUI>().text = second;
        quizBoard.transform.Find("Third").transform.Find("Text").GetComponent<TextMeshProUGUI>().text = third;
        quizBoard.transform.Find("Fourth").transform.Find("Text").GetComponent<TextMeshProUGUI>().text = fourth;
    }

    public void OnButtonClick(Button button)
    {
        string buttonName = button.gameObject.name;
        if(buttonName == answer)
        {
            textMesh.text = lastText;
            quizBoard.SetActive(false);
        }
        else
        {
            textMesh.text = "땡! 다시 골라줘~";
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        string collidedObjectName = collision.gameObject.name;

        switch (collidedObjectName)
        {
            case "NPC_ECC":
                textMesh.text = "안녕! 여긴 ECC라고 해. 이화여자대학교의 대표적인 건물이지.\n실제로 건물을 둘러본 후, 저기 뒤에 보이는 NPC에게 말을 걸어서 퀴즈를 맞춰줘~";
                break;
            case "NPC_ECC_Quiz":
                textMesh.text = "퀴즈! 교보문고는 ECC의 몇 층에 있을까?";
                quizBoard.SetActive(true);
                SetQuizText("지하 1층", "지하 2층", "지하 3층", "지하 4층");
                answer = "Fourth";
                lastText = "정답! 이제 길을 따라 다른 건물로 이동해보자~\n아! 풀들을 밟지 않게 조심해줘!";
                break;
            case "NPC_Culture_Center":
                textMesh.text = "여긴 학생문화관이야!\n여기는 조금만 둘러봐도 뭐하는 곳인지 금방 알 수 있을 거야.\n 둘러본 후에 저기 뒤에 보이는 NPC에게 다가가서 퀴즈를 풀어봐!";
                break;
        }

    }
}
