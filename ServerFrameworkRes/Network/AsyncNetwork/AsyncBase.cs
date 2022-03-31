using System;
using System.Collections.Generic;

namespace ServerFrameworkRes.Network.AsyncNetwork
{
    public abstract class AsyncBase
    {
        #region Fields

        private readonly List<AsyncState> states;

        #endregion Fields

        #region Constructors

        public AsyncBase()
        {
            states = new List<AsyncState>();
        }

        #endregion Constructors

        #region Methods

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

        #endregion Methods
    }
}