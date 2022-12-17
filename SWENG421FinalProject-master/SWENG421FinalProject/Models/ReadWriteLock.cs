using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace SWENG421FinalProject.Models.ReadWriteLock
{
    public class ReadWriteLock
    {
        private int readLock = 0;
        private int outstandingReadLocks = 0;

        private Thread writeLockThread;

        private List<Thread> waitingWriteLock = new List<Thread>();

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void ReadLock()
        {
            if (writeLockThread != null)
            {
                readLock++;
                while (writeLockThread != null)
                {
                    Monitor.Wait(writeLockThread);
                    readLock--;
                }
                outstandingReadLocks++;
            }
        }

        public void WriteLock()
        {
            Thread t;
            lock (this)
            {
                if (writeLockThread == null && outstandingReadLocks == 0)
                {
                    writeLockThread = Thread.CurrentThread;
                    return;
                }
                t = Thread.CurrentThread;
                waitingWriteLock.Add(t);
            }
            lock (t)
            {
                while (t != writeLockThread)
                {
                    Monitor.Wait(t);
                }
            }
            lock (this)
            {
                waitingWriteLock.Remove(t);
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Complete()
        {
            if (outstandingReadLocks > 0)
            {
                outstandingReadLocks--;
                if (outstandingReadLocks == 0 && waitingWriteLock.Count > 0)
                {
                    writeLockThread = (Thread)waitingWriteLock.FirstOrDefault();
                    lock (writeLockThread)
                    {
                        Monitor.PulseAll(writeLockThread);
                    }
                }
            }
            else if (Thread.CurrentThread == writeLockThread)
            {
                if (outstandingReadLocks == 0 && waitingWriteLock.Count > 0)
                {
                    writeLockThread = (Thread)waitingWriteLock.FirstOrDefault();
                    lock (writeLockThread)
                    {
                        Monitor.PulseAll(writeLockThread);
                    }
                }
                else
                {
                    writeLockThread = null;
                    if(readLock > 0)
                    {
                        Monitor.PulseAll(readLock);
                    }
                }
            }
        }
    }
}
