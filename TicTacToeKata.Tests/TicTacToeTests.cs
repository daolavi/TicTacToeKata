using TicTacToeKata.Logic;

namespace TicTacToeKata.Tests;

[TestFixture]
public class TicTacToeTests
{
    private TicTacToe _sut;
    
    [SetUp]
    public void SetUp()
    {
        _sut = new TicTacToe();
    }
    
    [Test]
    public void Initialise_ShouldCreateAnEmptyBoard()
    {
        foreach (var cell in _sut.Board)
        {
            Assert.That(cell, Is.EqualTo(null));
        }
    }
    
    [Test]
    public void Initialise_ShouldAllowXPlayerPlayingFirst()
    {
        Assert.That(_sut.CurrentPlayer, Is.EqualTo('X'));
    }

    [Test]
    public void Play_ShouldUpdateBoard()
    {
        _sut.MakeMove(0, 0);
        Assert.That(_sut.Board[0,0], Is.EqualTo('X'));
    }

    [Test]
    public void Play_ShouldAllowPlayersTakeTheirTurns()
    {
        _sut.MakeMove(0,0); //X
        Assert.That(_sut.Board[0,0], Is.EqualTo('X'));
        
        _sut.MakeMove(1,1); //O
        Assert.That(_sut.Board[1,1], Is.EqualTo('O'));
    }

    [Test]
    public void Play_ShouldNotAllowPlayersPlayOnOccupiedCells()
    {
        _sut.MakeMove(0,0); //X
        Assert.That(_sut.Board[0,0], Is.EqualTo('X'));
        
        Assert.Throws<Exception>(() => _sut.MakeMove(0, 0));
    }

    [Test]
    public void Play_ShouldNotAllowPlaying_WhenThereIsWinner_3InARow()
    {
        _sut.MakeMove(0,0); //X
        _sut.MakeMove(1,0); //O
        _sut.MakeMove(0,1); //X
        _sut.MakeMove(1,1); //O
        _sut.MakeMove(0,2); //X

        Assert.Throws<Exception>(() => _sut.MakeMove(1, 2));
    }
    
    [Test]
    public void Play_ShouldNotAllowPlaying_WhenThereIsWinner_3InAColumn()
    {
        _sut.MakeMove(0,0); //X
        _sut.MakeMove(0,1); //O
        _sut.MakeMove(1,0); //X
        _sut.MakeMove(1,1); //O
        _sut.MakeMove(2,0); //X

        Assert.Throws<Exception>(() => _sut.MakeMove(2, 1));
    }
    
    [Test]
    public void Play_ShouldNotAllowPlaying_WhenThereIsWinner_3InADiagonal()
    {
        _sut.MakeMove(0,0); //X
        _sut.MakeMove(1,0); //O
        
        _sut.MakeMove(1,1); //X
        _sut.MakeMove(2,0); //O
        
        _sut.MakeMove(2,2); //X

        Assert.Throws<Exception>(() => _sut.MakeMove(2, 1));
    }
    
    [Test]
    public void Play_ShouldNotAllowPlaying_WhenThereIsWinner_3InAForwardDiagonal()
    {
        _sut.MakeMove(2,0); //X
        _sut.MakeMove(1,0); //O
        
        _sut.MakeMove(1,1); //X
        _sut.MakeMove(0,0); //O
        
        _sut.MakeMove(0,2); //X

        Assert.Throws<Exception>(() => _sut.MakeMove(0, 1));
    }
    
    [Test]
    public void Play_ShouldNotAllowPlaying_WhenBoardIsCompleted()
    {
        /*
         X X O
         O X X
         X O O
         */
        _sut.MakeMove(0,0);//X
        _sut.MakeMove(0,1);
        _sut.MakeMove(1,1);//X
        _sut.MakeMove(0,2);
        _sut.MakeMove(1,2);//X
        _sut.MakeMove(1,0);
        _sut.MakeMove(2,0);//X
        _sut.MakeMove(2,2);
        _sut.MakeMove(2,1);//X

        Assert.Throws<Exception>(() => _sut.MakeMove(0, 3));
    }
    
    [Test]
    public void Complete_ReturnXAsWinner_WhenXPlayerWins()
    {
        _sut.MakeMove(0,0); //X
        _sut.MakeMove(0,1); //O
        _sut.MakeMove(1,0); //X
        _sut.MakeMove(1,1); //O
        _sut.MakeMove(2,0); //X

        Assert.That(_sut.Winner, Is.EqualTo('X'));
    }
    
    [Test]
    public void Complete_ReturnNull_WhenDraw()
    {
        /*
         X X O
         O X X
         X O O
         */
        _sut.MakeMove(0,0);//X
        _sut.MakeMove(0,1);
        _sut.MakeMove(1,1);//X
        _sut.MakeMove(0,2);
        _sut.MakeMove(1,2);//X
        _sut.MakeMove(1,0);
        _sut.MakeMove(2,0);//X
        _sut.MakeMove(2,2);
        _sut.MakeMove(2,1);//X

        Assert.That(_sut.Winner, Is.EqualTo(null));
    }
}