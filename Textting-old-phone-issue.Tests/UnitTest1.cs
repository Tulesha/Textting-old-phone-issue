using Textting_old_phone_issue;

namespace TestProject1;

public class Tests
{
    private Phone _phone;

    [OneTimeSetUp]
    public void Setup()
    {
        _phone = new Phone();
    }

    [Test]
    public void Should_Get_HG()
    {
        Assert.That(_phone.SendMessage("44 45*#"), Is.EqualTo("HG"));
    }

    [Test]
    public void Should_Get_HelloWorld()
    {
        Assert.That(_phone.SendMessage("4433555 555666096667775553#"), Is.EqualTo("HELLO WORLD"));
    }

    [Test]
    public void Should_Get_Dipaul()
    {
        Assert.That(_phone.SendMessage("34447288555#"), Is.EqualTo("DIPAUL"));
    }

    [Test]
    public void Should_Get_Hey()
    {
        Assert.That(_phone.SendMessage("4433999#"), Is.EqualTo("HEY"));
    }

    [Test]
    public void Should_Get_One_Two_Three()
    {
        Assert.That(_phone.SendMessage("666 6633089666084477733 33#"), Is.EqualTo("ONE TWO THREE"));
    }

    [Test]
    public void Should_Get_Hello_Without_World()
    {
        Assert.That(_phone.SendMessage("4433555 5556660#96667775553"), Is.EqualTo("HELLO"));
    }

    [Test]
    public void Should_Get_Empty()
    {
        Assert.That(_phone.SendMessage("  "), Is.EqualTo(""));
    }

    [Test]
    public void Should_Get_Empty_Without_Sharp()
    {
        Assert.That(_phone.SendMessage("34447288555"), Is.EqualTo(""));
    }

    [Test]
    public void Should_Get_Cycle_Letter()
    {
        Assert.That(_phone.SendMessage("22222#"), Is.EqualTo("B"));
    }

    [Test]
    public void Should_Get_Cycle_Letter_In_Message()
    {
        Assert.That(_phone.SendMessage("44444339999999#"), Is.EqualTo("HEY"));
    }

    [Test]
    public void Should_Throw_Exception1()
    {
        Assert.Catch<TextingException>(() => _phone.SendMessage("113345#"));
    }

    [Test]
    public void Should_Throw_Exception2()
    {
        Assert.Catch<TextingException>(() => _phone.SendMessage("44 45 test#"));
    }
}