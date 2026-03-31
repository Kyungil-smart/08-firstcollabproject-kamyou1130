using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnManager : MonoBehaviour
{
    [System.Serializable]
    public struct SpawnPrefab
    {
        public GameObject prefab;
        public string layer;
    }
    
    public List<SpawnPrefab> spawnPrefabs;
    private List<IRespawnable> _respawnable;
    public Transform tileMap;
    private UserInput _input;

    private void Awake()
    {
        Init();
    }

    private void OnEnable()
    {
        _input.asset.Enable();
        _input.System.Respawn.performed += OnRespawn;
    }

    private void OnDisable()
    {
        _input.System.Respawn.performed -= OnRespawn;
        _input.asset.Disable();
    }

    private void OnRespawn(InputAction.CallbackContext ctx)
    {
        Respawn();
    }

    private void Init()
    {
        _input = new UserInput();
        _respawnable = new List<IRespawnable>();
        Spawnning();
    }

    private void Respawn()
    {
        foreach (var gameObj in _respawnable)
        {
            gameObj?.Respawn();
        }
    }

    private void Spawnning()
    {
        SpriteRenderer[] dummys = tileMap.GetComponentsInChildren<SpriteRenderer>();

        foreach (var dummy in dummys)
        {
            string dummyLayer = LayerMask.LayerToName(dummy.gameObject.layer);
            
            SpawnPrefab prefab = spawnPrefabs.Find(prefab => prefab.layer == dummyLayer);

            if (prefab.prefab != null)
            {
                GameObject spawnObj = Instantiate(prefab.prefab, dummy.transform.position, Quaternion.identity);

                IRespawnable respawnable = spawnObj.GetComponent<IRespawnable>();
                if (respawnable != null) _respawnable.Add(respawnable);
                
                if (dummy.transform.position.y < -1)
                {
                    spawnObj.transform.rotation = Quaternion.Euler(0, 0, 180f);
                    
                    if (spawnObj.TryGetComponent<Obstacle.Obstacle>(out Obstacle.Obstacle obstacle))
                    {
                        obstacle._isThisObjBelongsToTheReverseWorld = true;
                        obstacle.ReversingState();
                    }
                    else if (spawnObj.TryGetComponent<SadFruit>(out SadFruit sadfruit))
                    {
                        sadfruit._rb.gravityScale = -1;
                    }
                    else if (spawnObj.TryGetComponent<PlayerController>(out PlayerController playerController))
                    {
                        float gravity = -1f;
                        bool reverseState = true;
                        
                        playerController.SpawnReverseState(reverseState, gravity);
                    }
                }
                else if (dummy.transform.position.y > 1 && spawnObj.TryGetComponent<HappyFruit>(out HappyFruit happyFruit)) happyFruit._rb.gravityScale = 1;
                
                Destroy(dummy.gameObject);
            }
        }
    }
}
