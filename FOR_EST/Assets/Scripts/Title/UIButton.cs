using UnityEngine;
using UnityEngine.SceneManagement;
public class UIButton : MonoBehaviour
{
    public GameObject titlePanel; //TitlePanel의 GameObject를 넣어주세요.
    public GameObject settingsPanel; //SettingsPanel의 GameObject를 넣어주세요.
    public GameObject creditsPanel; //CreditsPanel의 GameObject를 넣어주세요.

    
    public void NewGame()
    {
        SceneManagement.Instance.LoadScene("SampleScene"); //"SampleScene"을 새로 만들 씬의 이름으로 바꿔주세요.
    }

    public void LoadGame()
    {
        Debug.Log("LoadGame버튼은 아직 미구현입니다!");
    }

    public void OpenTitlePanel() //Return 버튼을 누르면 titlePanel이 켜지고 나머지 패널은 꺼지도록 하는 함수입니다.
    {
        titlePanel.SetActive(true);
        settingsPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }
    public void OpneSettingsPanel() // Settings 버튼을 누르면 settingsPanel이 켜지고 나머지 패널은 꺼지도록 하는 함수입니다.
    { 
        titlePanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void OpenCreditPanel() // Credits 버튼을 누르면 creditsPanel이 켜지고 나머지 패널은 꺼지도록 하는 함수입니다.
    {
        titlePanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void Quit()
    { 
        UnityEditor.EditorApplication.isPlaying = false; //유니티 에디터에서 Play만 비활성화 시키는 함수
        //Application.Quit(); 실제 빌드에서는 게임 종료 시키려면 이 함수 활성화 해야 함
    }
}