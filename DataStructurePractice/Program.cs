using System;

namespace DataStructurePractice
{
    class Program
    {
        static void Main(string[] args)
        {
            var myList = new LinkedList<int>();
            myList.addFirst(5);
            myList.addLast(1);
            myList.addLast(2);
            myList.addLast(3);
            myList.addAt(4,1);
            var element = myList.deleteAT(2);

        }

    }
    public class Node<T> : IComparable<T>
    {
        public T Element { get; set; }
        public Node<T> Next { get; set; }

        public Node(T element, Node<T> next)
        {
            Element = element;
            Next = next;
        }

        public int CompareTo(T? other)
        {
            if (other.Equals(Element))
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }
    public class LinkedList<T>
    {
        private Node<T> _head;
        private Node<T> _tail;
        
        public void addFirst(T element)
        {
            if(_head == null)
            {
                _head = new Node<T>(element, _tail); 
            }
            else
            {
                var temp = _head;
                _head = new Node<T>(element, temp);
            }
        }
        public void addLast(T element)
        {
            if (_tail == null && _head == null)
            {
                _head = new Node<T>(element, _tail);
            }
            else
            {
                Node<T> prev = null;
                var current = _head;
                while(current != null)
                {
                    prev = current;
                    current = current.Next;
                }
                prev.Next = new Node<T>(element,_tail);
            }
        }
        public T deleteAT(int index)
        {
            if (_tail == null && _head == null)
            {
                throw new Exception("List is empty");
            }
            else
            {
                int count = 0;
                var current = _head;
                Node<T> prev = null;
                bool isDeleted = false;

                while (current != null)
                {
                    if (count == index)
                    {
                        prev.Next = current.Next;
                        current.Next = null;
                        isDeleted = true;
                        return current.Element;
                    }
                    prev = current;
                    current = current.Next;
                    count++;
                }
                if (!isDeleted)
                {
                    throw new Exception("Index out of bond");
                }

                return default(T);
            }
        }
        public void addAt(T element,int index)
        {
            if (_tail == null && _head == null)
            {
                throw new Exception("List is empty");
            }
            else
            {
                int count = 0;
                var current = _head;
                Node<T> prev = null;
                bool isAdded = false;

                while (current != null)
                {
                    if(count == index)
                    {
                        prev.Next = new Node<T>(element, current);
                        isAdded = true;
                        return;
                    }
                    prev = current;
                    current = current.Next;
                    count++;
                }
                if (!isAdded)
                {
                    throw new Exception("Index out of bond");
                }
            }
        }

    }
}
