using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;
using System.Drawing;
using System.Diagnostics;
using FractalRendererLibrary.Events;

namespace FractalRendererLibrary.Renderer
{
    

    /// <summary>
    /// Active Object
    /// </summary>
    public class RendererThread : IDisposable
    {
        private bool _stopped;
        private bool _disposed;
        private AutoResetEvent _autoresetEvent;
        private Queue _syncQueue;
        private readonly Thread _thread;
        private List<Action<CancellableRenderingEventArg>> _renderActions = new List<Action<CancellableRenderingEventArg>>();
        private CancellableRenderingEventArg _currentCancellableArg;

        public RendererThread()
        {
            _syncQueue = new Queue();
            _syncQueue = Queue.Synchronized(_syncQueue);
            _autoresetEvent = new AutoResetEvent(false);
            _thread = new Thread(new ThreadStart(Render));
            _thread.IsBackground = true;
            _thread.Start();
        }

        public void Enqueue(Action<CancellableRenderingEventArg> action)
        {
            _syncQueue.Clear();//Get rid of previous requests, serve only the last one!
            _syncQueue.Enqueue(action);
            if(_currentCancellableArg != null)//Cancel the current rendering
                _currentCancellableArg.Cancel();
            _autoresetEvent.Set();
        }

        private void Render()
        {
            while (!_stopped)
            {
                try
                {
                    if (_syncQueue.Count > 0)
                    {
                        _currentCancellableArg = new CancellableRenderingEventArg();
                        Action<CancellableRenderingEventArg> currentAction = _syncQueue.Dequeue() as Action<CancellableRenderingEventArg>;
                        currentAction(_currentCancellableArg);
                    }
                    if (_syncQueue.Count == 0)
                        _autoresetEvent.WaitOne();
                }
                catch (Exception e)
                {
                    Debug.Write(e.Message, "Exception");
                }
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _stopped = true;
                    _autoresetEvent.Set();
                    _autoresetEvent.Dispose();
                }
                _disposed = true;
            }
        }
    }
}
