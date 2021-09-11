using MementoPattern;

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