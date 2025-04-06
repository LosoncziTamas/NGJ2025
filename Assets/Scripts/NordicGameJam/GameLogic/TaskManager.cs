using UnityEngine;

namespace NordicGameJam.GameLogic
{
    public class TaskManager : MonoBehaviour
    {
        int TaskAmount;
        int TasksComplete;

        // Start is called before the first frame update
        void Start()
        {
        
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
                //activateFinaltask
                Debug.Log("Go To Bed!");
            }

        }
    }
}
