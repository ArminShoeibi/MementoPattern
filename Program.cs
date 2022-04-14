using System.Collections.Concurrent;

Editor notepadPlusPlus = new();
History notepadPlusPlusClipBoard = new();

notepadPlusPlus.SetContent("Hello");
notepadPlusPlusClipBoard.Push(notepadPlusPlus.CreateState());
Console.WriteLine(notepadPlusPlus.Content);


notepadPlusPlus.SetContent("How are you?");
notepadPlusPlusClipBoard.Push(notepadPlusPlus.CreateState());
Console.WriteLine(notepadPlusPlus.Content);

notepadPlusPlus.SetContent("Cool!");
notepadPlusPlus.RestoreContent(notepadPlusPlusClipBoard.Pop());
Console.WriteLine(notepadPlusPlus.Content);



record class EditorState(string Content);
record class History
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

record class Editor
{
    public string Content { get; private set; }

    public void SetContent(string content) => Content = content;
    public EditorState CreateState() => new EditorState(Content);
    public void RestoreContent(EditorState editorState) => SetContent(editorState.Content);
}


