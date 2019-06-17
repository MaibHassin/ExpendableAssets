using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Pathfinding : MonoBehaviour
{

    Grid grid;
    public Transform StartPosition;
    public Transform TargetPosition;
    public GameObject PathBlock;
    public GameObject[] PathList;
    private int count = 10;
    public Transform[] buildingP;

    private void Awake()
    {
        grid = GetComponent<Grid>();
    }

    private void Update()
    {
        count++;
        if(count > 9)
        {
            count = 0;
            FindPath(StartPosition.position, TargetPosition.position);
        }
        
    }

    void FindPath(Vector3 a_StartPos, Vector3 a_TargetPos)
    {
        Node StartNode = grid.NodeFromWorldPosition(a_StartPos);
        Node TargetNode = grid.NodeFromWorldPosition(a_TargetPos);
        List<Node> OpenList = new List<Node>();
        HashSet<Node> ClosedList = new HashSet<Node>();
        OpenList.Add(StartNode);

        while(OpenList.Count > 0)
        {
            Node CurrentNode = OpenList[0];
            for(int i = 1; i < OpenList.Count; i++)
            {
                if(OpenList[i].FCost < CurrentNode.FCost || OpenList[i].FCost == CurrentNode.FCost && OpenList[i].hCost < CurrentNode.hCost)
                {
                    CurrentNode = OpenList[i];
                }
            }
            OpenList.Remove(CurrentNode);
            ClosedList.Add(CurrentNode);
            if(CurrentNode == TargetNode)
            {
                GetFinalPath(StartNode, TargetNode);
            }
            foreach(Node NeighbourNode in grid.GetNeighboringNodes(CurrentNode))
            {
                if(!NeighbourNode.IsWall || ClosedList.Contains(NeighbourNode))
                {
                    continue;
                }
                int MoveCost = CurrentNode.gCost + GetManhattenDistance(CurrentNode, NeighbourNode);
                if(MoveCost < NeighbourNode.gCost || !OpenList.Contains(NeighbourNode))
                {
                    NeighbourNode.gCost = MoveCost;
                    NeighbourNode.hCost = GetManhattenDistance(NeighbourNode, TargetNode);
                    NeighbourNode.Parent = CurrentNode;
                    if (!OpenList.Contains(NeighbourNode) || MoveCost < NeighbourNode.FCost)
                    {
                        OpenList.Add(NeighbourNode);
                    }
                }
            }
        }
    }

    void GetFinalPath(Node a_StartingNode, Node a_EndNode)
    {
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("PathBlock");
        foreach (GameObject PathBlock in blocks)
        {
            GameObject.Destroy(PathBlock);
        }
        List<Node> FinalPath = new List<Node>();
        Node CurrentNode = a_EndNode;
        while(CurrentNode != a_StartingNode)
        {
            FinalPath.Add(CurrentNode);
            CurrentNode = CurrentNode.Parent;
            Instantiate(PathBlock, CurrentNode.Position + new Vector3(0, 40, 0), Quaternion.identity);
        }
        FinalPath.Reverse();
        grid.FinalPath = FinalPath;
    }

    int GetManhattenDistance(Node a_nodeA, Node a_nodeB)
    {
        int ix = Mathf.Abs(a_nodeA.gridX - a_nodeB.gridX);
        int iy = Mathf.Abs(a_nodeA.gridY - a_nodeB.gridY);
        return ix + iy;
    }
}