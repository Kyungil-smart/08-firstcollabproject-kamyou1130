using System;
using System.Collections;
using UnityEditor;
using UnityEngine;

public class EditorHelper : MonoBehaviour
{
    GUIStyle style = new GUIStyle();
    private void OnDrawGizmos()
    {
        Vector3 size = new Vector3(2.5f, 1.5f, 1.0f);
        Vector3 pos = new Vector3(size.x * 0.5f, -size.y * 0.5f, 0.0f);
        
        Gizmos.color = new Color(0,0,0,0.5f);
        Gizmos.DrawCube(transform.position + pos, size);
        
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position,0.5f);
        
        style.normal.textColor = Color.red;
        Handles.Label(transform.position, $"x : {transform.position.x}\ny : {transform.position.y}", style);
    }

    public void StartDestroy()
    {
        StartCoroutine(Destroyer());
    }
    private IEnumerator Destroyer()
    {
        yield return YieldContainer.WaitForSeconds(3.0f);
        DestroyImmediate(gameObject);
    }
}
