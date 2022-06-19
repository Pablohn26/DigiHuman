using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SlideShow : MonoBehaviour
{
    [SerializeField] private UnityEvent onMoveNext;
    [SerializeField] private UnityEvent onMoveLast;
    public Action<int,GameObject> onSelection; //add your actions to this function
    [Header("Nodes and properties")]
    [SerializeField] private float scrollDuration;
    [SerializeField] private float speed;
    [SerializeField] private float distanceBetweenNodes;
    [SerializeField] private Transform centerNodePos;
    [SerializeField] private List<GameObject> nodes;
    [SerializeField] private GameObject parent; // parent game object of all nodes
    private int index = 0;


    private void Awake()
    {
        nodes ??= new List<GameObject>();
        InitialSlideShowPanel();
    }

    private bool playingCoroutine;

    private void InitialSlideShowPanel()
    {
        if(nodes.Count == 0)
            return;
        nodes[0].transform.position = centerNodePos.position;
        for (int i = 1; i < nodes.Count; i++)
        {
            Vector3 targetPos = nodes[i-1].transform.position + Vector3.right * distanceBetweenNodes;
            nodes[i].transform.position = targetPos; 
        }
    }
    

    public void AddNode(GameObject node)
    {
        node.transform.parent = parent.transform;
        if (nodes.Count != 0)
        {
            Vector3 targetPos = nodes[nodes.Count - 1].transform.position + Vector3.right * distanceBetweenNodes;
            node.transform.position = targetPos;
            nodes.Add(node);
        }
        else
        {
            node.transform.position = centerNodePos.position;
            nodes.Add(node);
        }
    }
    
    public void MoveLast()
    {
        if (!playingCoroutine && index > 0)
        {
            index--;
            playingCoroutine = true;
            onMoveLast.Invoke();
            StartCoroutine(PlayAnimation(true));
        }
    }
    public void MoveNext()
    {
        if (!playingCoroutine && index+1 < nodes.Count)
        {
            index++;
            playingCoroutine = true;
            onMoveNext.Invoke();
            StartCoroutine(PlayAnimation(false));
        }
    }

    public IEnumerator PlayAnimation(bool isMovingRight)
    {
        float move = distanceBetweenNodes;
        if (!isMovingRight)
            move = -move;
        Vector3 initialPos = parent.transform.position;
        Vector3 finalPos = parent.transform.position + Vector3.right * move;
        float timePassed = 0;
        float portion = 0.0f;
        while (true)
        {
            parent.transform.position = Vector3.Slerp(initialPos, finalPos, portion);
            if(portion >= 1)
                break;
            yield return new WaitForEndOfFrame();
            timePassed += Time.deltaTime * speed;
            portion = (timePassed) / (scrollDuration);
        }
        playingCoroutine = false;
        yield break;
    }

    public void OnSelectItem()
    {
        onSelection(index,nodes[index]);
    }
}