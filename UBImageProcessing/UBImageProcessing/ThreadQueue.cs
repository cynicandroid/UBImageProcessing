// UB Image Processing Tool
//Final Year Project
//CPSC 597A-A/597B-A
//ADV Probs-CPSC
//By: Saroj Poudyal 
//ID: 0732761


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace UBImageProcessing
{
    class ThreadQueue
    {
        // This ThreadQueue Code is highly referred to this UBImageProcessing from one of the openSource Project
        //from CodePlex
        //This Code was Suitablly changed to suit our Project of Image Processing 
        // By : Saroj Poudyal 


        private WorkItemQueue m_WorkQueue;
        private WaitCallback oWaitCallback;

        private int m_ItemsProcessing;
        private int m_NoParallelThreads;

        private object m_Lock_WorkItem = new object();

        /// <summary>
        /// Configures how many concurrent threads can be dispatching the workerqueue
        
        public ThreadQueue(int NoParallelThreads)
        {
            #region Configure Thread Count
            int iWorkerThreads = 0;
            int iCompletionPortThreads = 0;

            ThreadPool.GetMaxThreads(out iWorkerThreads, out iCompletionPortThreads);

            m_NoParallelThreads = NoParallelThreads > iWorkerThreads ? iWorkerThreads : NoParallelThreads;

            Debug.WriteLine(String.Format("PrioritisedWorkerQueue.Constr: Requested:{0} Availible:{1}", NoParallelThreads, m_NoParallelThreads));
            #endregion

            m_WorkQueue = new WorkItemQueue();
            m_ItemsProcessing = 0;

            oWaitCallback = new WaitCallback(InvokeWaitHandleDelegate);

            
        }

        ~ThreadQueue()
        {
            
        }

        /// <summary>
        /// Place a new waitcallback pointer to you method on the queue. Null will be passed as
        /// the parameter to the method.
        /// </summary>
       
        public void QueueUserWorkItem(WaitCallback Method)
        {
            QueueUserWorkItem(Method, null);
        }

        /// <summary>
        /// Place a new waitcallback pointer to you method on the queue. The second parameter will be passed
        /// to your method.
        /// </summary>
        
        public void QueueUserWorkItem(WaitCallback Method, Object State)
        {
            QueueUserWorkItem(Method, State, ThreadPriority.Normal);
        }

        /// <summary>
        /// Place a new waitcallback pointer to you method on the queue. The second parameter will be passed
        /// to your method.
        /// 
        /// The priority is used to sort the pending workitems, prior to them being placed on the threadpool,
        /// once they are being executed that are running with the same priority.
        /// </summary>
        
        public void QueueUserWorkItem(WaitCallback Method, Object State, ThreadPriority Priority)
        {
            QueueUserWorkItem(Method, State, Priority, Guid.NewGuid().ToString());
        }

        /// <summary>
        /// Place a new waitcallback pointer to you method on the queue. The second parameter will be passed
        /// to your method.
        /// 
        /// The priority is used to sort the pending workitems, prior to them being placed on the threadpool,
        /// once they are being executed that are running with the same priority.
        /// 
        /// If a key is shared between 2 workitems, and one is already on the queue when another is attempted to be
        /// placed on the queue, then the second one isnt place upon the queue.
        
        /// </summary>
        
        public void QueueUserWorkItem(WaitCallback Method, Object State, ThreadPriority Priority, object ItemKey)
        {
            WorkItem oPThreadWorkItem = new WorkItem(Method, State, Priority, ItemKey);

            QueueUserWorkItem(oPThreadWorkItem);
        }

        /// <summary>
        /// Private method that queues the work item, and ensures that a thread is executing to process the queue.
        /// 
        /// This method starts the dispatching of the work, however, subsequent invocations will be spawned by the 
        /// threadpool itself.
        /// </summary>
       
        private void QueueUserWorkItem(WorkItem oPThreadWorkItem)
        {
            lock (m_Lock_WorkItem)
            {
                m_WorkQueue.AddPrioritised(oPThreadWorkItem);
            }

            if (m_ItemsProcessing < m_NoParallelThreads) //Spawn another thread.
                SpawnWorkThread(null);
        }

       
        
        private void SpawnWorkThread(IAsyncResult AsyncResult)
        {
            lock (m_Lock_WorkItem)
            {
                if (AsyncResult != null)
                {
                    oWaitCallback.EndInvoke(AsyncResult);

                    m_ItemsProcessing--;

                    #region Removes the ManualReset from the collection, indicating it is processed.
                    WorkItem oPThreadWorkItem = AsyncResult.AsyncState as WorkItem;

                    if (oPThreadWorkItem != null)
                    {
                        m_WorkQueue.ManualResets.Remove(oPThreadWorkItem.MRE);
                    }
                    #endregion

                }

                // oWorker item will be null if the queue was empty
                if (m_WorkQueue.Count > 0)
                {
                    m_ItemsProcessing++;

                    //Gets the next piece of work to perform
                    WorkItem oWorkItem = m_WorkQueue.Dequeue();

                    if (oWorkItem != null)
                    {
                        //Hooks up the callback to this method.		
                        AsyncCallback oAsyncCallback = new AsyncCallback(this.SpawnWorkThread);

                        //Invokes the work on the threadpool					
                        oWaitCallback.BeginInvoke(oWorkItem, oAsyncCallback, oWorkItem);

                    }
                }

            }
        }

        /// <summary>
        /// Can only be called by <see cref="SpawnWorkThread"/> it is where the pointer to the method 
        /// is invoked, and the parameter is passed to the method.
        /// 
        /// Importantly, this is where reset event is set, to indicate that work has been completed.
        /// </summary>
        
        private void InvokeWaitHandleDelegate(object Item)
        {
            try
            {
                WorkItem oWorkItem = Item as WorkItem;

                try
                {
                    oWorkItem.Method.Invoke(oWorkItem.State);
                }
                catch (Exception Ex)
                {
                    Debug.WriteLine("InvokeWaitHandleDelegate.Ex.2:" + Ex.ToString());
                }
                finally
                {
                    oWorkItem.MRE.Set(); //ManualResetEvent is set, in order to flag it is completed.
                }
            }
            catch (Exception Ex)
            {
                Debug.WriteLine("InvokeWaitHandleDelegate.Ex.1:" + Ex.ToString());
            }
        }


        /// <summary>
        /// This causes the work queue to block, until all the currently queued workitems have been processed. 
        /// It takes a snapshot of the pending items, and waits for them to process.
        /// 
        /// This code will wait for all pending items to be processed, then it will unblock
        ///         
        /// </summary>
        /// <returns>The number of remaining worker items</returns>
        public int WaitAll()
        {
            lock (this)
            {
                //This collection is changed by many threads, it must therefore be copied before it is enumerated.
                List<ManualResetEvent> oCopy = new List<ManualResetEvent>(m_WorkQueue.ManualResets);

                foreach (ManualResetEvent oMR in oCopy)
                    oMR.WaitOne();

                return m_WorkQueue.ManualResets.Count;
            }
        }

        public WorkItemQueue WorkQueue
        {
            get { return m_WorkQueue; }
        }
    }

    class WorkItem : IComparable<WorkItem>
    {
        private WaitCallback m_Method;
        private Object m_ObjectState;
        private ThreadPriority m_Priority;
        private ManualResetEvent m_MRE;
        private object m_ItemKey;

        
       
        public WorkItem(WaitCallback method, Object state, ThreadPriority priority, object ItemKey)
        {
            m_Method = method;
            m_ObjectState = state;
            m_Priority = priority;
            m_ItemKey = ItemKey;

            m_MRE = new ManualResetEvent(false);
        }

        public ThreadPriority Priority { get { return m_Priority; } }
        public WaitCallback Method { get { return m_Method; } }
        public Object State { get { return m_ObjectState; } }
        public Object Key { get { return m_ItemKey; } }
        public ManualResetEvent MRE { get { return m_MRE; } }

        #region IComparable<PThreadWorkItem> Members

        public int CompareTo(WorkItem other)
        {
            return this.Priority.CompareTo(other.Priority);
        }

        #endregion
    }

    class WorkItemQueue
    {
        private object m_Lock_WorkItem_AddRemove;

        private List<WorkItem> m_WorkItems;
        private List<ManualResetEvent> m_MREs;

        public WorkItemQueue()
        {
            m_Lock_WorkItem_AddRemove = new object();

            m_WorkItems = new List<WorkItem>();
            m_MREs = new List<ManualResetEvent>();
        }

        /// <summary>
        /// Removes the next highest priority work item from the queue.
        /// </summary>
       
        public WorkItem Dequeue()
        {
            lock (m_Lock_WorkItem_AddRemove)
            {
                if (m_WorkItems.Count > 0)
                {
                    WorkItem o = m_WorkItems[m_WorkItems.Count - 1];
                    m_WorkItems.RemoveAt(m_WorkItems.Count - 1);
                    return o;
                }

                return null;
            }
        }

        /// <summary>
        /// Adds items to the work queue.
        /// 
        /// If the unique for the item already exists, then the work item is discarded.
        /// 
        /// If the priority is greater than previous items in the queue, then the new work item is
        /// inserted prior to the other items.
        /// </summary>
        
        public void AddPrioritised(WorkItem oNewItem)
        {
            lock (m_Lock_WorkItem_AddRemove)
            {
                foreach (WorkItem oItem in m_WorkItems)
                    if (oItem.Key.ToString() == oNewItem.Key.ToString())
                    {
                        Debug.WriteLine("PrioritisedArrayList: Key Already Queued: Skipped Request");
                        return;
                    }

                m_MREs.Add(oNewItem.MRE);

                int i = m_WorkItems.BinarySearch(oNewItem);

                if (i < 0)
                    m_WorkItems.Insert(~i, oNewItem);
                else
                    m_WorkItems.Insert(i, oNewItem);
            }
        }

        public List<ManualResetEvent> ManualResets
        {
            get { return m_MREs; }
        }

        public int Count
        {
            get { return m_WorkItems.Count; }
        }
    }
    
}
