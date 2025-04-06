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
            FinalTask.GetComponent<BoxCollider>().enabled = false;
            //find every task in level


            TaskAmount = GameObject.FindGameObjectsWithTag("Task").Length;

            Debug.Log(TaskAmount);
            TasksComplete = 0;
        }

        public void UpdateTaskCounter()
        {
            TasksComplete++;

            if (TasksComplete == TaskAmount)
            {
                FinalTask.GetComponent<BoxCollider>().enabled = true;
            }

        }
    }
}
