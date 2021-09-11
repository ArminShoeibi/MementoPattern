namespace MementoPattern;

public record Editor
{
    public string Content { get; private set; }

    public void SetContent(string content) => Content = content;
    public EditorState CreateState() => new EditorState(Content);
    public void RestoreContent(EditorState editorState) => SetContent(editorState.Content);
}
