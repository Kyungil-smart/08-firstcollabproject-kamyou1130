using UnityEngine;
using System.Collections.Generic;
public class ChatSystem : MonoBehaviour
{
    public Queue<string> sentences; //string을 담을 Queue를 선언한다.
    public void Ondialogue(string[]lines) //Ondialogue()함수가 호출되면 Npc의 대사를 전달받아서 큐에 저장한다. Ondialogue의 매개변수로 string 배열을 추가한다.
    { 
        sentences = new Queue<string>(); //sentences를 새로운 Queue로 초기화한다.
        sentences.Clear(); //sentences에 저장된 모든 요소를 제거한다.

    }
}
