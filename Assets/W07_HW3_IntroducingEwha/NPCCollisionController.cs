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
                textMesh.text = "여긴 학생문화관이야!\n여기는 조금만 둘러봐도 뭐하는 곳인지 금방 알 수 있을 거야.\n둘러본 후에 저기 뒤에 보이는 NPC에게 다가가서 퀴즈를 풀어봐!";
                break;
            case "NPC_Culture_Center_Quiz":
                textMesh.text = "퀴즈! 이곳 학생문화관의 목적과 가장 연관있는 키워드는?";
                quizBoard.SetActive(true);
                SetQuizText("수업", "연구", "동아리", "학생회");
                answer = "Third";
                lastText = "정답! 내 뒤에 있는 사과 문으로 들어가봐! 순간이동을 시켜줄게!";
                break;
            case "Portal":
                gameObject.GetComponent<Transform>().position = new Vector3(13500f, 0f, 200f);
                textMesh.text = "어딘가로 순간이동 했습니다. 여긴 어딜까요? 앞의 NPC에게 다가가봅시다!";
                break;
            case "NPC_Engineering":
                textMesh.text = "여기에도 사람이 오다니 신기하다...\n이곳은 이화여대의 꼭대기에 있는 공대라고 해. 정문에서부터 왔다고? 대단하다.\n별 건 없지만 둘러보고 저 뒤에 있는 NPC에게 말을 걸어서 퀴즈를 풀어줘.";
                break;
            case "NPC_Engineering_Quiz":
                textMesh.text = "우와 사람이다...\n퀴즈! 공대에 존재하지 않는 것은?";
                quizBoard.SetActive(true);
                SetQuizText("수면실", "샤워실", "식당", "과방");
                answer = "First";
                lastText = "정답!\n...이제 모든 공간을 다 본 것 같네! 공간 소개는 여기서 끝이야.\n하지만 공대는 입구는 있지만 출구는 없어... 넌 이제 여기 갇히게 된거야.";
                break;
        }

    }
}
