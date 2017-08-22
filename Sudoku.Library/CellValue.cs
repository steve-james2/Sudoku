using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Library
{

    [DebuggerDisplay( "Name" )]
    [SuppressMessage( "ReSharper", "UseNullPropagation" )]
    public class CellValue
    {
        public static CellValue One = new CellValue( "1" );
        public static CellValue Two = new CellValue( "2" );
        public static CellValue Three = new CellValue( "3" );
        public static CellValue Four = new CellValue( "4" );
        public static CellValue Five = new CellValue( "5" );
        public static CellValue Six = new CellValue( "6" );
        public static CellValue Seven = new CellValue( "7" );
        public static CellValue Eight = new CellValue( "8" );
        public static CellValue Nine = new CellValue( "9" );

        static List<CellValue> _all = new List<CellValue>() { One, Two, Three, Four, Five, Six, Seven, Eight, Nine };

        public static IReadOnlyList<CellValue> All => _all;

        public string Name { get; }

        private CellValue( string name )
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

        #region Equals override

        public override bool Equals( object obj )
        {
            if ( obj == null )
                return false;

            var p = obj as CellValue;
            if ( (object)p == null )
                return false;

            return Equals( p );
        }

        public bool Equals( CellValue p )
        {
            if ( (object)p == null )
                return false;

            return p.Name == Name;
        }

        public static bool operator ==( CellValue a, CellValue b )
        {
            if ( ReferenceEquals( a, b ) )
                return true;

            if ( ( (object)a == null ) || ( (object)b == null ) )
                return false;

            // Return true if the fields match:
            return a.Equals( b );
        }

        public static bool operator !=( CellValue a, CellValue b )
        {
            return !( a == b );
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        #endregion
    }
}
