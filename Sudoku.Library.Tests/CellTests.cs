using NUnit.Framework;
using NSubstitute;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku.Library.Tests
{
    [TestFixture]
    public class CellTests
    {

        [Test]
        public void Contructor_NullOrEmptyParameter_ThrowsException()
        {
            ( (Action)( () => new Cell( null ) ) ).ShouldThrow<ArgumentNullException>();
            ( (Action)( () => new Cell( new List<CellValue>() ) ) ).ShouldThrow<ArgumentException>();
        }

        [Test]
        public void Constructor_ValidParameter_CellHasPossibleValues()
        {
            // Arrange

            // Act 
            var cell = new Cell( CellValue.All );

            //Assert
            cell.PossibleValues.ShouldAllBeEquivalentTo( CellValue.All );
        }

        [Test]
        public void MustBe_AnImpossibleValue_ThrowsException()
        {
            // Arrange

            // Act 

            //Assert
            true.Should().BeFalse();
        }

        [Test]
        public void MustBe_APossibleValue_ValueIsSetToTheMustBeValue()
        {
            // Arrange

            // Act 

            //Assert
            true.Should().BeFalse();
        }

        [Test]
        public void CannotBe_AllPossibleValues_ThrowsException()
        {
            // Arrange

            // Act 

            //Assert
            true.Should().BeFalse();
        }

        [Test]
        public void CannotBe_ASubsetOfPossibleValues_RemovesValuesFromPossibleValues()
        {
            // Arrange

            // Act 

            //Assert
            true.Should().BeFalse();
        }

        [Test]
        public void CannotBe_AnImpossibleValue_NoEffect()
        {
            // Arrange

            // Act 

            //Assert
            true.Should().BeFalse();
        }
    }
}