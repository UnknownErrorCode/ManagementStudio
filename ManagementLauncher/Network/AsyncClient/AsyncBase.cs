using System;
using System.Collections.Generic;

namespace ManagementLauncher.Network.AsyncClient
{
    public abstract class AsyncBase
    {
        #region Private Fields

        private readonly List<AsyncState> states;

        #endregion Private Fields

        #region Public Constructors

        public AsyncBase()
        {
            states = new List<AsyncState>();
        }

        #endregion Public Constructors

        #region Public Methods

        public void AddState(AsyncState state)
        {
            lock (states)
            {
                states.Add(state);
            }
        }

        public void RemoveState(AsyncState state)
        {
            lock (states)
            {
                states.Remove(state);
            }
        }

        public void Tick()
        {
            lock (states)
            {
                foreach (AsyncState state in states)
                {
                    try
                    {
                        state.Context.Interface.OnTick(state.Context);
                    }
                    catch (Exception) { }
                }
            }
        }

        #endregion Public Methods
    }
}