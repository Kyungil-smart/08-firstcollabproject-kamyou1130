using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class CutSceneManager : SingletonMonoBehaviour<CutSceneManager>
{
    private StateMachine CutSceneState;
    [SerializeField]private CinemachineCamera _cinemaCameraPrefab;
    private CinemachineCamera _cinemaCamera;
    private Dictionary<string, ScenarioSO> Scenarios = new ();

    [SerializeField] private ScenarioSO testSO;
    
    
    
    protected override void Awake(){
        base.Awake();
        SetCamera();
        //특정 위치의 시나리오 모두 로드.
        
        //임시 추가
        if(!testSO)
            Scenarios["start"] = testSO;
    }

    private void SetCamera()
    {
        _cinemaCamera = Instantiate(_cinemaCameraPrefab, transform); 
    }


    public void StartCutscene(string cutSceneName)
    {
        
    }
    
}
