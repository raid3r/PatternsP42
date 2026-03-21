using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsP42.Behavioral;

public class MementoClientCode
{
    public void Run()
    {
        var editor = new Editor { Content = "Hello, world!", FontSize = 12, FontFamily = "Arial" };
        var caretaker = new Caretaker();
        caretaker.SaveState(editor);

        editor.Content = "Hello, C#!";
        caretaker.SaveState(editor);

        editor.FontSize = 12;
        caretaker.SaveState(editor);
        // скасувати зміни та повернутися до попереднього стану
        editor.Content = "Hello, Memento!";
        caretaker.SaveState(editor);
        editor.FontSize = 14;
        caretaker.SaveState(editor);

        editor.Content = "Hello, C#!";
        caretaker.SaveState(editor);


       // editor.FontSize = 12;
        caretaker.SaveState(editor);
       // editor.Content = "Hello, Memento!";
        caretaker.SaveState(editor);
       // editor.FontSize = 14;
        caretaker.SaveState(editor);
       // editor.FontFamily = "Times New Roman";
        caretaker.SaveState(editor);

        // 5 кроків назад
        caretaker.RestoreState(editor);
         caretaker.RestoreState(editor);
            caretaker.RestoreState(editor);
            caretaker.RestoreState(editor);
            caretaker.RestoreState(editor);





    }
}

public class Memento
{
    public string Content { get; }
    public int FontSize { get; }
    public string FontFamily { get; }
    public Memento(string content, int fontSize, string fontFamily)
    {
        Content = content;
        FontSize = fontSize;
        FontFamily = fontFamily;
    }
}

public class Caretaker
{
    private List<Memento> _mementos = new List<Memento>();

    public void SaveState(Editor editor)
    {
        _mementos.Add(editor.CreateMemento());
    }
    public void RestoreState(Editor editor)
    {
        var previousState = _mementos.LastOrDefault();

        if (previousState != null)
        {
            editor.RestoreMemento(previousState);
        }
        _mementos.Remove(previousState);
    }
}


public class Editor
{
    public string Content { get; set; }
    public int FontSize { get; set; }
    public string FontFamily { get; set; }

    public Memento CreateMemento()
    {
        return new Memento(Content, FontSize, FontFamily);
    }

    public void RestoreMemento(Memento memento)
    {
        Content = memento.Content;
        FontSize = memento.FontSize;
        FontFamily = memento.FontFamily;
    }
}
