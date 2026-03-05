using System.Runtime.CompilerServices;
using System.Xml;

namespace LinkedListIntroduction.Lib;

public class IntegerLinkedList
{
    IntegerNode _head;
   
    public IntegerLinkedList()
    {
        _head = null;
    }

    public IntegerLinkedList(int v)
    {
        _head = new IntegerNode(v);
    }

    public int Count => _head == null ? 0 : _head.Count;
    public int Sum => _head == null ? 0 : _head.Sum;

    public void Append(int v)
    {
        if (_head == null)
            _head = new IntegerNode(v);
        else
            _head.Append(v);

    }

    public void Prepend(int v)
    {
        var NewHead = new IntegerNode(v);
        NewHead.Append(_head._value);
        if (_head._next != null)
        {
            NewHead._next = _head._next;
        }
        _head = NewHead;
    }

    public bool Remove(int v)
    {
        if (_head == null)
        {
            return false;
        }
        if (_head._value == v)
        {
           return true;
           _head = _head._next; 
        }
        var current = _head;
        while (current._next != null && current._next._value !=v)
        {
            current = current._next;
        }
        if (current._next != null) //jump over
        {
            current._next = current._next._next;
            return true;
        }
        return false;
    }


    public void Insert(int value, int index)
    {
        IntegerNode newNode = new IntegerNode(value);

        if (index == 0)
        {
            newNode._next = _head;
            _head = newNode;
            return;
        }
        
        IntegerNode current = _head;
        int count = 0;
        while(current != null && count < index)
        {
            current = current._next;
            count++;
        }

        if (current == null)
        {
            Console.WriteLine("Index out of bounds");
        }
        
        else
        {
            newNode._next = current._next;
            current._next = newNode;
        }
    }
    public override string ToString()
    {
        return _head == null ? "{}" : $"{{{_head}}}";
    }

    
}

public class IntegerNode
{
    public int _value;
    public IntegerNode _next;

     internal int Count => _next == null ? 1 : 1 + _next.Count;
            
    internal int Sum => _next == null ? _value : _value + _next.Sum;


    internal IntegerNode(int v)
    {
        _value = v;
        _next = null;
    }


    internal void Append(int v)
    {
        if (_next == null)
            _next = new IntegerNode(v);
        else
            _next.Append(v);
    }

    public override string ToString()
    {
        return _next == null ? _value.ToString() : $"{_value}, {_next}";
    }

}
