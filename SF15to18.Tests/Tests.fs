namespace SF15to18.Tests

open System
open Microsoft.VisualStudio.TestTools.UnitTesting
open Microsoft.VisualStudio.TestPlatform.TestHost
open Program

[<TestClass>]
type SF15to18Tests () =

    [<TestMethod>]
    member this.LookupIndex () =
        let expected = 'N';
        let actual = Program.lookupIndex(13);
        Assert.AreEqual(expected, actual);

    [<TestMethod>]
    member this.ConvertToInt32 () =
        let expected = Convert.ToInt32("00100", 2);
        let actual = Program.convertToInt32("00100");
        Assert.AreEqual(expected, actual);

    [<TestMethod>]
    member this.ConvertID () =
        let expected = "a0S0k0000043cPeEAI";
        let actual = Program.convertID("a0S0k0000043cPe");
        Assert.AreEqual(expected, actual);

    [<TestMethod>]
    member this.ConvertArgvToID () =
        let expected = "a0S0k0000043cPeEAI";
        let actual = Program.convertArgvToID([|"a0S0k0000043cPe"|]);
        Assert.AreEqual(expected, actual);

    [<TestMethod>]
    member this.ConvertArgvToIDNoID () =
        let expected = "Please enter an ID of 15 chars";
        let actual = Program.convertArgvToID([||]);
        Assert.AreEqual(expected, actual);

    [<TestMethod>]
    member this.Main () =
        let expected = 0;
        let actual = Program.main[|"a0S0k0000043cPeEAI"|];
        Assert.AreEqual(expected, actual);
