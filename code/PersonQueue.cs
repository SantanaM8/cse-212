/// <summary>
/// A basic implementation of a Queue
/// </summary>
public class PersonQueue {
    private readonly List<Person> _queue = new List<Person>();

    public int Length => _queue.Count;

    /// <summary>
    /// Add a person to the queue
    /// </summary>
    /// <param name="person">The person to add</param>
    public void Enqueue(Person person) {
        _queue.Add(person);
    }

    public Person Dequeue() {
        if (_queue.Count == 0)
        {
            Console.WriteLine("The queue is empty");
            return null;
        }

        var person = _queue[0];
        _queue.RemoveAt(0);
        return person;
    }

    public bool IsEmpty() {
        return Length == 0;
    }

    public override string ToString() {
        return $"[{string.Join(", ", _queue)}]";
    }
}