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
        textMesh.text = "��ȭ���ڴ��б��� �� ���� ȯ���մϴ�!\n����� ���� ������ �ֽ��ϴ�!\n�� �տ� �ٷ� �ǹ��� ���̳׿�. �ǹ� ���� NPC���� �ٰ��� ���ô�.";
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
            textMesh.text = "��! �ٽ� �����~";
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        string collidedObjectName = collision.gameObject.name;

        switch (collidedObjectName)
        {
            case "NPC_ECC":
                textMesh.text = "�ȳ�! ���� ECC��� ��. ��ȭ���ڴ��б��� ��ǥ���� �ǹ�����.\n������ �ǹ��� �ѷ��� ��, ���� �ڿ� ���̴� NPC���� ���� �ɾ ��� ������~";
                break;
            case "NPC_ECC_Quiz":
                textMesh.text = "����! ��������� ECC�� �� ���� ������?";
                quizBoard.SetActive(true);
                SetQuizText("���� 1��", "���� 2��", "���� 3��", "���� 4��");
                answer = "Fourth";
                lastText = "����! ���� ���� ���� �ٸ� �ǹ��� �̵��غ���~\n��! Ǯ���� ���� �ʰ� ��������!";
                break;
            case "NPC_Culture_Center":
                textMesh.text = "���� �л���ȭ���̾�!\n����� ���ݸ� �ѷ����� ���ϴ� ������ �ݹ� �� �� ���� �ž�.\n �ѷ��� �Ŀ� ���� �ڿ� ���̴� NPC���� �ٰ����� ��� Ǯ���!";
                break;
        }

    }
}
