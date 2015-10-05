using System;
using System.Collections.Generic;

public class TaskQueue 
{
	public delegate void Task();

	private readonly Queue<Task> taskQueue;
	private readonly object queueLock = new object();

	public TaskQueue()
	{
		this.taskQueue = new Queue<Task>();
	}

	public void ProcessNext()
	{
		lock (this.queueLock)
		{
			if (this.taskQueue.Count > 0)
				this.taskQueue.Dequeue()();
		}
	}

	public void AddTask(Task task)
	{
		this.taskQueue.Enqueue(task);
	}
}