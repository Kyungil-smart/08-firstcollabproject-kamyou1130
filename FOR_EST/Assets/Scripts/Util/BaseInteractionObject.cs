using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public abstract class BaseInteractionObject : MonoBehaviour, IPullable, IRespawnable
{
    [Header("플레이어와 장애물 간의 상호작용 가능 거리")] 
    [SerializeField] protected float _linkDist = 0.5f;
    
    [Header("오브젝트 재생성 대기시간 설정")] 
    [SerializeField] protected float _respawnTime = 1f;
    
    [Header("바닥으로 감지될 거리")]
    [SerializeField] protected float _groundDistance;
        
    [Header("바닥을 감지 할 박스의 x축 크기")]
    [SerializeField] protected float _groundSizeX = 1.02f;
    
    protected Vector2 _spawnPos;
    protected Transform _playerHand;
    public Rigidbody2D _rb;
    protected SpriteRenderer _renderer;
    protected Collider2D _collider;
    protected bool _isPulling = false;
    protected bool _isRespawning = false;
    private string regex = new string(",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
    protected TextAsset _fruitTextFile;
    protected Canvas _textBoxCanvas;
    protected TextMeshProUGUI _text;
    protected List<FruitDialogueData> _fruitDataList = new List<FruitDialogueData>();
    protected FruitDialogueData _targetData;
    
    public virtual void Update()
    {
        if (_isPulling && _playerHand != null)
        {
            Vector2 grabPoint = _collider.ClosestPoint(_playerHand.position);
            float dist = Vector2.Distance(grabPoint, _playerHand.position);

            if (dist > _linkDist)
            {
                OnStopPull();
            }
        }
    }

    public virtual void Init()
    {
        _fruitTextFile = Resources.Load<TextAsset>("SadFruit");
        _fruitDataList = new List<FruitDialogueData>();
        _rb = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();
        _textBoxCanvas = GetComponentInChildren<Canvas>();
        _text = GetComponentInChildren<TextMeshProUGUI>();
        _spawnPos = transform.position;
        _text.text = GetTextLanguage(_targetData);
        
        PullingState(false);
    }
    
    public void LoadCSV()
    {
        string[] lines = _fruitTextFile.text.Split('\n');

        for (int i = 1; i < lines.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(lines[i])) continue;
            
            string[] row = Regex.Split(lines[i], regex);

            if(row.Length < 2) continue;
            
            FruitDialogueData data = new FruitDialogueData();
            
            data.id = int.Parse(row[0].Trim().Replace("\uFEFF", ""));
            data.textKR = row[1].Trim('\"'); 
            data.textEN = row[2].Trim('\"');
            data.textJP = row[3].Trim();
        
            _fruitDataList.Add(data);
        }
    }
    
    protected string GetTextLanguage(FruitDialogueData data)
    {
        if (data == null) return "";

        switch (LanguageSetting.currentLanguage)
        {
            case Language.KR: return data.textKR;
            case Language.EN: return data.textEN;
            case Language.JP: return data.textJP;
            default: return data.textKR;
        }
    }
    
    public virtual void OnPull(Transform playerHand)
    {
        _isPulling = true;
        _playerHand = playerHand;
        PullingState(_isPulling);
    }

    public virtual void OnStopPull()
    {
        if (_playerHand != null)
        {
            var player = _playerHand.GetComponentInParent<PlayerController>();
            if (player != null) player?.OffGrab();
        }
        _isPulling = false;
        _playerHand = null;
        PullingState(_isPulling);
    }

    public virtual void Respawn()
    {
        gameObject.SetActive(true);
        if (_isRespawning) return;
        OnStopPull();
        _isRespawning = true;
        transform.position = _spawnPos;
        _rb.linearVelocity = Vector2.zero;
        PullingState(false);
        _isRespawning = false;
    }
    
    public virtual void CheckGroundState(out Vector2 origin, out Vector2 checkBoxSize, out float direction)
    {
        direction = Mathf.Sign(_rb.gravityScale);
        float checkY = (direction > 0) ? _collider.bounds.min.y : _collider.bounds.max.y;

        origin = new Vector2(_collider.bounds.center.x, checkY);
        checkBoxSize = new Vector2(_collider.bounds.size.x * _groundSizeX, 0.05f);
    }

    public virtual void PullingState(bool isPulling)
    {
        if (isPulling) _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        else           _rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
    }

    public virtual void RespawningState(bool isEnabled)
    {
        _rb.simulated = isEnabled;
        _renderer.enabled = isEnabled;
        _collider.enabled = isEnabled;
    }

    public void SetDataWithID(int id)
    {
        if(_fruitDataList == null) LoadCSV();
        
        _targetData = _fruitDataList.Find(x => x.id == id);
        if  (_targetData != null) _text.text = GetTextLanguage(_targetData);
    }
}

[System.Serializable] public class FruitDialogueData
{
    public int id;
    public string textKR;
    public string textEN;
    public string textJP;
}
