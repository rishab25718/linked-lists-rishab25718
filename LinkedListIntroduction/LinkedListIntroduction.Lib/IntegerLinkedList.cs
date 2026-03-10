using System.Runtime.CompilerServices;
using System.Transactions;
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

    public void Join(IntegerLinkedList list)
    {
        if (list == null || list._head == null)
        {
            return;
        }

        if (_head == null)
        {
            _head = list._head;
        }

        IntegerNode current = _head;
        while (current._next != null)
        {
            current = current._next;
        }

        current._next = list._head;
    }


    public bool Contains(int v)
    {
        if (_head == null)
        {
            return false;
        }

        IntegerNode current = _head;
        while (current._value != v)
        {
            current = current._next;
            if (current._value == v)
            {
                return true;
            }
        }
        return false;
    }

    public void RemoveDuplicates()
    {
        if (_head == null)
        {
            return;
        }

        IntegerNode current = _head;

        while (current != null)
        {
            IntegerNode duplicateChecker = current._next;
            while (duplicateChecker != null)
            {
                if (duplicateChecker == current)
                {
                    Remove(current._value);
                }
                duplicateChecker = duplicateChecker._next;
            }

            current = current._next;
        }
    }

    public void MergeAlternating(IntegerLinkedList list)
    {
       if (list == null || list._head == null)
        {
            return;
        }

        if (_head == null)
        {
            _head = list._head;
        }

        int index = 1;

        IntegerNode currentOtherList = list._head;

        while (currentOtherList != null)
        {
            list.Remove(currentOtherList._value);

            Insert(index, currentOtherList._value);

            index = index + 2;
            currentOtherList = list._head;
            
        }
    }

    public void Reverse()
    {
        if (_head == null)
        {
            return;
        }

        IntegerNode current = _head;
        int index = 1;

        IntegerNode currentTwo = _head;
        int count = 0;
        while (currentTwo != null)
        {
            currentTwo = currentTwo._next;
            count = count + 1;
        }

        while (current != null)
        {
            Remove(current._value);
            int value = current._value;
            current = current._next;
            Insert(count - index, value);
            
        }
    }

    public void SortedIntegerLinkedList()
    {
        IntegerLinkedList list = new IntegerLinkedList();

        IntegerNode current = _head;
        while (current != null)
        {
            int index = 0;
            IntegerNode currentSorted = list._head;
            while (currentSorted != null && currentSorted._value < current._value)
            {
                index = index + 1;
                currentSorted = currentSorted._next;
            }

            list.Insert(index, current._value);

            current  = current._next;
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
