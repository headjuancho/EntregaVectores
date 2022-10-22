using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{

    private const int IndexOfSquareChild = 0;
    private const int IndexOfCircleChild = 1;
    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    private int totalLevels = 3;

    [SerializeField]

    private float initialSize = 5f;

    [SerializeField, Range(0, 1)]
    private float reductionPerLevel = 0.1f;

    private int currentLevel = 1;

    private Queue<GameObject> branchQueue = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
       GameObject rootBranch = Instantiate(prefab, transform);
        ChangeSize(rootBranch, initialSize);
        branchQueue.Enqueue(rootBranch);
        GenerateTree();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void GenerateTree()
    {

        if (currentLevel >= totalLevels)
        {
            return;
        }

        currentLevel++;

        float newSize = Mathf.Max(initialSize - initialSize * reductionPerLevel * (currentLevel - 1), 0.1f);

        var branchesCreatedThisCycle = new List<GameObject>();

        while (branchQueue.Count >0 )
        {
            var rootbranch = branchQueue.Dequeue();

            var leftBranch = CreateBranch(rootbranch, Random.Range(5f, 30f));
            var rightBranch = CreateBranch(rootbranch, -Random.Range(5f, 30f));

            ChangeSize(leftBranch, newSize);
            ChangeSize(rightBranch, newSize);

            branchesCreatedThisCycle.Add(leftBranch);
            branchesCreatedThisCycle.Add(rightBranch);
        }

        foreach (var newBranch in branchesCreatedThisCycle)
        {
            branchQueue.Enqueue(newBranch);
        }

        GenerateTree();

    }

    private GameObject CreateBranch(GameObject previousBranch, float relativeAngle)
    {
        GameObject newBranch = Instantiate(prefab, transform);

        newBranch.transform.localPosition= previousBranch.transform.localPosition + previousBranch.transform.up* GetBranchLength(previousBranch);
        newBranch.transform.localRotation = previousBranch.transform.localRotation * Quaternion.Euler(0, 0, relativeAngle);

        return newBranch;


    }


    private void ChangeSize(GameObject branchInstance, float newSize)
    {
        var square = branchInstance.transform.GetChild(IndexOfSquareChild);
        var circle = branchInstance.transform.GetChild(IndexOfCircleChild);

        var newScale = square.transform.localScale;

        newScale.y = newSize;

        square.transform.localScale = newScale;

        var newPosition = square.transform.localPosition;
        newPosition.y = newSize / 2;
        square.transform.localPosition = newPosition;

        var newCirclePosition = circle.transform.localPosition;
        newCirclePosition.y = newSize;
        circle.transform.localPosition = newCirclePosition;

    }

    private float GetBranchLength(GameObject branchInstance)
    {
        return branchInstance.transform.GetChild(IndexOfSquareChild).localScale.y;
    }
}
