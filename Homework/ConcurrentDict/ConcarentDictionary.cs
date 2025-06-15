namespace ConcurentDictionary
{
    public class SpinLockDictionary<TKey, TValue>
    {
        private Dictionary<TKey, TValue> _dictionary = new Dictionary<TKey, TValue>();
        private int _lockState = 0;

        public bool TryAdd(TKey key, TValue value)
        {
            SpinWait spin = new SpinWait();

            while (true)
            {
                if (TryAcquireLock())
                {
                    try
                    {
                        if (_dictionary.ContainsKey(key))
                            return false;

                        _dictionary.Add(key, value);
                        return true;
                    }
                    finally
                    {
                        ReleaseLock();
                    }
                }
                spin.SpinOnce();
            }
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return _dictionary.TryGetValue(key, out value);
        }

        public bool TryRemove(TKey key, out TValue value)
        {
            SpinWait spin = new SpinWait();

            while (true)
            {
                if (TryAcquireLock())
                {
                    try
                    {
                        if (_dictionary.TryGetValue(key, out value))
                        {
                            _dictionary.Remove(key);
                            return true;
                        }
                        return false;
                    }
                    finally
                    {
                        ReleaseLock();
                    }
                }
                spin.SpinOnce();
            }
        }

        public bool TryUpdate(TKey key, TValue newValue)
        {
            SpinWait spin = new SpinWait();

            while (true)
            {
                if (TryAcquireLock())
                {
                    try
                    {
                        if (_dictionary.ContainsKey(key))
                        {
                            _dictionary[key] = newValue;
                            return true;
                        }
                        return false;
                    }
                    finally
                    {
                        ReleaseLock();
                    }
                }
                spin.SpinOnce();
            }
        }

        private bool TryAcquireLock()
        {
            return Interlocked.CompareExchange(ref _lockState, 1, 0) == 0;
        }

        private void ReleaseLock()
        {
            Volatile.Write(ref _lockState, 0);
        }
    }
}