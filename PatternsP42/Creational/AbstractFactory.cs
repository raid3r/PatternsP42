using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsP42.Creational;

public interface IButton
{
    void Render();
}

public interface ITextBox
{
    void Render();
}

public interface ILabel
{
    void Render();
}

public class LightButton : IButton
{
    public void Render() => Console.WriteLine("Render Light Button");
}

public class DarkButton : IButton
{
    public void Render() => Console.WriteLine("Render Dark Button");
}

public class GreenButton : IButton
{
    public void Render() => Console.WriteLine("Render Green Button");
}

public class GreenTextBox: ITextBox
{
    public void Render() => Console.WriteLine("Render Green TextBox");
}

public class GreenLabel : ILabel
{
    public void Render() => Console.WriteLine("Render Green Label");
}

public class LightTextBox : ITextBox
{
    public void Render() => Console.WriteLine("Render Light TextBox");
}

public  class DarkTextBox : ITextBox
{
    public void Render() => Console.WriteLine("Render Dark TextBox");
}

public class LigthLabel : ILabel
{
    public void Render() => Console.WriteLine("Render Light Label");
}

public class DarkLabel: ILabel
{
    public void Render() => Console.WriteLine("Render Dark Label");
}

public class Site
{
    public IButton Button { get; set; }
    public ITextBox TextBox { get; set; }
    public ILabel Label { get; set; }

    public void Render()
    {
        Button.Render();
        TextBox.Render();
        Label.Render();
    }
}

public abstract class SiteFactory
{
    public abstract IButton CreateButton();
    public abstract ITextBox CreateTextBox();
    public abstract ILabel CreateLabel();
}


public class LightSiteFactory : SiteFactory
{
    public override IButton CreateButton() => new LightButton();
    public override ITextBox CreateTextBox() => new LightTextBox();
    public override ILabel CreateLabel() => new LigthLabel();
}

public class DarkSiteFactory : SiteFactory
{
    public override IButton CreateButton() => new DarkButton();
    public override ITextBox CreateTextBox() => new DarkTextBox();
    public override ILabel CreateLabel() => new DarkLabel();
}

public class GreenSiteFactory : SiteFactory
{
    public override IButton CreateButton() => new GreenButton();
    public override ITextBox CreateTextBox() => new GreenTextBox();
    public override ILabel CreateLabel() => new GreenLabel();
}

public class DarkGreenSiteFactory : GreenSiteFactory
{
    public override IButton CreateButton() => new DarkButton();
}