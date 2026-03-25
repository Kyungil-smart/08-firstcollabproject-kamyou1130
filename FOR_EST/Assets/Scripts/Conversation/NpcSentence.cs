using UnityEngine;

public class NpcSentence : MonoBehaviour
{
    public string[] sentences; //NPC들의 대사를 담을 string 배열을 선언한다.
    public Transform chatTransform; //대화창이 나타날 위치를 지정하기 위한 Transform 변수를 선언한다.
    public GameObject chatBoxPrefab; //ChatBox 프리팹을 저장할 GameObject 변수를 선언한다.

    public void seedNpc()
    { 
        GameObject copyChat = Instantiate(chatBoxPrefab);
        copyChat.GetComponent<ChatSystem>().Ondialogue();
    }
}
