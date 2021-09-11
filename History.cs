using System.Collections.Concurrent;

namespace MementoPattern;

public record History
{
    private ConcurrentStack<EditorState> _editorStates = new();
    public void Push(EditorState editorState) => _editorStates.Push(editorState);
    public EditorState Pop()
    {
        bool isReturned = _editorStates.TryPop(out var editorState);
        if (isReturned)
            return editorState;
        else
            return null;
    }
}
