using UnityEngine;

namespace NordicGameJam.GameLogic
{
    public class TaskManager : MonoBehaviour
    {
        int TaskAmount;
        int TasksComplete;

        public GameObject FinalTask;

        // Start is called before the first frame update
        void Start()
        {
            FinalTask.GetComponent<BoxCollider>().enabled = true;
            //find every task in level
            TaskAmount = GameObject.FindGameObjectsWithTag("Task").Length;        
            TasksComplete = 0;

            Debug.Log(TaskAmount);
        }

        public void UpdateTaskCounter()
        {
            TasksComplete++;
            Debug.Log(TasksComplete);

            if (TasksComplete == TaskAmount)
            {
                FinalTask.GetComponent<BoxCollider>().enabled = true;
            }

        }
    }
}
