﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseApi
{
    public delegate void QueueEventHandler<T, U>(T sender, U eventArgs); // Delcare delegate

    public class CustomQueue<T> where T : IEntityPrimaryProperties, IEntityAdditionalProperties
    {
        Queue<T> _queue = null;

        public event QueueEventHandler<CustomQueue<T>, QueueEventArgs> CustomQueueEvent; // Declare event, which is a type of the delegate declared above

        public CustomQueue() // Constructor
        {
            _queue = new Queue<T>();
        }

        public int QueueLength
        {
            get { return _queue.Count; }
        }

        public void AddItem(T item)
        {
            _queue.Enqueue(item);

            QueueEventArgs queueEventArgs = new QueueEventArgs {  Message = $"DateTime: {DateTime.Now.ToString(Constants.DateTimeFormat)}, Id: {item.Id}, Name: {item.Name}, Type: {item.Type}, Quantity: {item.Quantity}, has been added to the queue."};

            OnQueueChanged(queueEventArgs);
        }

        public T GetItem()
        {
            T item = _queue.Dequeue();

            QueueEventArgs queueEventArgs = new QueueEventArgs { Message = $"DateTime: {DateTime.Now.ToString(Constants.DateTimeFormat)}, Id: {item.Id}, Name: {item.Name}, Type: {item.Type}, Quantity: {item.Quantity}, has been processed." };

            OnQueueChanged(queueEventArgs);

            return item;

        }

        protected virtual void OnQueueChanged(QueueEventArgs a) 
        {
            CustomQueueEvent(this, a);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _queue.GetEnumerator();
        }
    }
}
