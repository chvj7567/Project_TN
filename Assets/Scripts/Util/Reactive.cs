using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;

public class ReactiveCollection<ValueType>
{
    private List<ValueType> _list;

    public event Action<ValueType> OnAdd;
    public event Action<bool> OnRemove;

    public int Count => _list.Count;

    public ReactiveCollection()
    {
        _list = new List<ValueType>();
    }

    public void Add(ValueType value)
    {
        _list.Add(value);
        OnAdd?.Invoke(value);
    }

    public bool Remove(ValueType value)
    {
        bool result = _list.Remove(value);
        OnRemove?.Invoke(result);

        return result;
    }

    public ValueType Last()
    {
        if (Count == 0)
            return default(ValueType);

        return _list[Count - 1];
    }

    public void ForEach(Action<ValueType> callback)
    {
        foreach (ValueType value in _list)
        {
            callback?.Invoke(value);
        }
    }

    public ValueType Find(Predicate<ValueType> predicate)
    {
        foreach (ValueType pair in _list)
        {
            if (predicate(pair))
            {
                return pair;
            }
        }

        return default(ValueType);
    }
}

public class ReactiveDictionary<KeyType, ValueType>
{
    private Dictionary<KeyType, ValueType> _dictionary;

    public event Action<KeyValuePair<KeyType, ValueType>> OnAdd;
    public event Action<bool> OnRemove;

    public int Count => _dictionary.Count;

    public ReactiveDictionary()
    {
        _dictionary = new Dictionary<KeyType, ValueType>();
    }

    public void Add(KeyType key, ValueType value)
    {
        if (_dictionary.ContainsKey(key))
            return;

        _dictionary.Add(key, value);
        OnAdd?.Invoke(new KeyValuePair<KeyType, ValueType>(key, value));
    }

    public bool Remove(KeyType key)
    {
        bool result = _dictionary.Remove(key);
        OnRemove?.Invoke(result);

        return result;
    }

    public KeyValuePair<KeyType, ValueType> Last()
    {
        int index = 0;
        foreach (var pair  in _dictionary)
        {
            if (index - 1 == Count)
                return pair;

            ++index;
        }

        return default(KeyValuePair<KeyType, ValueType>);
    }

    public void ForEach(Action<KeyValuePair<KeyType, ValueType>> callback)
    {
        foreach (KeyValuePair<KeyType, ValueType> pair in _dictionary)
        {
            callback?.Invoke(pair);
        }
    }

    public KeyValuePair<KeyType, ValueType> Find(Predicate<KeyValuePair<KeyType, ValueType>> predicate)
    {
        foreach (KeyValuePair<KeyType, ValueType> pair in _dictionary)
        {
            if (predicate(pair))
            {
                return pair;
            }
        }

        return default(KeyValuePair<KeyType, ValueType>);
    }
}